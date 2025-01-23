using HardkorowyKodsu.Backend.Tables.DataAccess.Entities;

namespace HardkorowyKodsu.Backend.Tables.DataAccess.Interfaces;

public interface ITablesDao
{
	Task<IReadOnlyCollection<TableSummary>> GetTablesSummaryAsync();

	Task<IReadOnlyCollection<TableColumn>> GetTableColumnsAsync(int tableId);
}
