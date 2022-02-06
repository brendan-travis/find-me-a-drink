using System.Data;
using Core.Factories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.Factories;

public class DbConnectionFactory : IDbConnectionFactory
{
    public DbConnectionFactory(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }
    
    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(this.Configuration["ConnectionStrings:Database"]);
    }
}