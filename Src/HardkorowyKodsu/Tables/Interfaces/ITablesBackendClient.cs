using HardkorowyKodsu.Backend.Tables.DataAccess.Entities;
using HardkorowyKodsu.Backend.Tables.Dto;

namespace HardkorowyKodsu.Tables.Interfaces;

internal interface ITablesBackendClient
{
	Task<IEnumerable<GetTablesReturnDto>> GetTablesAsync(CancellationToken cancellationToken);

	Task<GetTableReturnDto> GetTableDetailsAsync(int tableId, CancellationToken cancellationToken);
}
