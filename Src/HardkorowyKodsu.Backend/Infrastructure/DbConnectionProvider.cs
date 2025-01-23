using System.Data.Common;
using HardkorowyKodsu.Backend.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;

namespace HardkorowyKodsu.Backend.Infrastructure;

public class DbConnectionProvider : IDbConnectionProvider
{
	private readonly IConfiguration mConfiguration;

	public DbConnectionProvider(IConfiguration configuration)
	{
		mConfiguration = configuration;
	}

	public async Task<DbConnection> GetConnectionAsync(CancellationToken cancelToken)
	{
		var connection = new SqlConnection(mConfiguration.GetConnectionString("Default"));
		try
		{
			await connection.OpenAsync(cancelToken);
			return connection;
		}
		catch
		{
			await connection.DisposeAsync();
			throw;
		}
	}
}
