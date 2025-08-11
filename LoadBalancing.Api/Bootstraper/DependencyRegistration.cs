using Npgsql;
using System.Security.Cryptography;

namespace LoadBalancing.Api.Bootstraper;

public static class DependencyRegistration
{
    public static void RegisterPostgresSql(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        var dataSource = new NpgsqlDataSourceBuilder(connectionString).Build();
        builder.Services.AddSingleton(dataSource);
    }
}
