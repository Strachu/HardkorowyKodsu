using Dapper;
using HardkorowyKodsu.Backend.Infrastructure.Interfaces;
using HardkorowyKodsu.Backend.Tables.DataAccess.Entities;
using HardkorowyKodsu.Backend.Tables.DataAccess.Interfaces;

namespace HardkorowyKodsu.Backend.Tables.DataAccess;

public class TablesDao : ITablesDao
{
	private readonly IDbConnectionProvider mConnectionProvider;

	public TablesDao(IDbConnectionProvider connectionProvider)
	{
		mConnectionProvider = connectionProvider;
	}

	public async Task<IReadOnlyCollection<TableSummary>> GetTablesSummaryAsync()
	{
		var sql = $"""
			SELECT
				[obj].[object_id] AS [Id],
				[obj].[name] AS [Name],
				[s].[name] AS [Schema]
			FROM [sys].[objects] AS [obj]
				JOIN [sys].[schemas] [s] ON [obj].[schema_id] = [s].[schema_id]
			WHERE [type] IN ('U', 'V')
			ORDER BY [Schema], [Name]
			""";

		await using(var connection = await mConnectionProvider.GetConnectionAsync())
		{
			return (await connection.QueryAsync<TableSummary>(sql)).ToList();
		}
	}
}
