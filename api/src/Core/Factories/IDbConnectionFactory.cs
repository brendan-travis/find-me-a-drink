using System.Data;

namespace Core.Factories;

public interface IDbConnectionFactory
{
    /// <summary>
    /// Gets a valid <see cref="IDbConnection"/>.
    /// </summary>
    /// <returns>An <see cref="IDbConnection"/> used to connect to a data source.</returns>
    IDbConnection GetConnection();
}