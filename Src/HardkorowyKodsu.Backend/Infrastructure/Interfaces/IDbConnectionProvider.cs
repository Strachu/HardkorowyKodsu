using System.Data.Common;

namespace HardkorowyKodsu.Backend.Infrastructure.Interfaces;

public interface IDbConnectionProvider
{
	Task<DbConnection> GetConnectionAsync(CancellationToken cancelToken = default);
}
