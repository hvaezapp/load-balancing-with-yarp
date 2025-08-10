using Bogus;
using Dapper;
using Npgsql;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");
var dataSource = new NpgsqlDataSourceBuilder(connectionString).Build();
builder.Services.AddSingleton(dataSource);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

await EnsureUserTable(app.Services);

app.MapPost("addUser", async (NpgsqlDataSource source) =>
{
    var faker = new Faker();

    await using var connection = await source.OpenConnectionAsync();

    var userId = await connection.ExecuteScalarAsync<int>(
        """
        INSERT INTO users (first_name, last_name, date_of_birth)
        VALUES (@FirstName, @LastName, @DateOfBirth)
        RETURNING id;
        """,
        new User
        {
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            DateOfBirth = faker.Date.Past(20).ToUniversalTime()
        });

    connection.Close();

    return Results.Ok(new { id = userId });
});

app.MapGet("getAllUsers", async (NpgsqlDataSource source) =>
{
    await using var connection = await source.OpenConnectionAsync();
    var users = await connection.QueryAsync<User>(
        """
        SELECT
            id AS Id,
            first_name AS FirstName,
            last_name AS LastName,
            date_of_birth AS DateOfBirth
        FROM users
        ORDER BY id;
        """
    );

    return Results.Ok(users);
});

app.Run();


#region EnsureUserTable
static async Task EnsureUserTable(IServiceProvider services)
{
    await using var scope = services.CreateAsyncScope();
    var dataSource = scope.ServiceProvider.GetRequiredService<NpgsqlDataSource>();

    await using var connection = await dataSource.OpenConnectionAsync();

    var exists = await connection.ExecuteScalarAsync<bool>(
        """
        SELECT EXISTS (
            SELECT FROM information_schema.tables 
            WHERE table_schema = 'public' 
            AND table_name = 'users'
        );
        """
    );

    if (!exists)
    {
        await connection.ExecuteAsync(
            """
            CREATE TABLE users (
                id SERIAL PRIMARY KEY,
                first_name TEXT NOT NULL,
                last_name TEXT NOT NULL,
                date_of_birth TIMESTAMP NOT NULL
            );
            """
        );
    }

}
#endregion