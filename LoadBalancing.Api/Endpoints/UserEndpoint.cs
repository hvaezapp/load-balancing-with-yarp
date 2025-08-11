using Dapper;
using LoadBalancing.Api.Models.Dtos;
using Npgsql;

namespace LoadBalancing.Api.Endpoints;

public static class UserEndpoint
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("addUser", async (CreateUserDto dto,
                                               NpgsqlDataSource source) =>
        {
            await using var connection = await source.OpenConnectionAsync();
            var userId = await connection.ExecuteScalarAsync<int>(
                """
                    INSERT INTO users (first_name, last_name, date_of_birth)
                    VALUES (@FirstName, @LastName, @DateOfBirth)
                    RETURNING id;
                """,
                new
                {
                    dto.FirstName,
                    dto.LastName,
                    dto.DateOfBirth

                });

            connection.Close();
            return Results.Ok(new { id = userId });
        });

        routeBuilder.MapGet("users", async (NpgsqlDataSource source) =>
        {
            await using var connection = await source.OpenConnectionAsync();

            var user = await connection.QuerySingleAsync<GetUserDto>(
                """
                 SELECT
                    id AS Id,
                    first_name AS FirstName,
                    last_name AS LastName,
                    date_of_birth AS DateOfBirth
                 FROM users
                """);

            connection.Close();
            return Results.Ok(user);

        });

        routeBuilder.MapGet("users/{id}", async (int id, NpgsqlDataSource source) =>
        {
            await using var connection = await source.OpenConnectionAsync();

            var user = await connection.QuerySingleAsync<GetUserDto>(
                """
                 SELECT
                    id AS Id,
                    first_name AS FirstName,
                    last_name AS LastName,
                    date_of_birth AS DateOfBirth
                 FROM users
                 WHERE id = @UserId
                """,
                new { UserId = id });

            connection.Close();
            return Results.Ok(user);

        });
    }
}
