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

	public async Task<IReadOnlyCollection<TableColumn>> GetTableColumnsAsync(int tableId)
	{
		var sql = $"""
			SELECT
				[c].[name] AS [Name],
				[t].[name] AS [TypeName],
				[c].[is_nullable] AS [IsNullable]
			FROM [sys].[columns] c
			JOIN [sys].[types] t ON [t].[user_type_id] = [c].[user_type_id]
			WHERE [c].[object_id] = @tableId
			ORDER BY [c].[Name]
			""";

		await using(var connection = await mConnectionProvider.GetConnectionAsync())
		{
			return (await connection.QueryAsync<TableColumn>(sql, new { tableId = tableId })).ToList();
		}
	}
}
