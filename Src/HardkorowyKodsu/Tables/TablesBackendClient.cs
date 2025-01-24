using System.Net.Http.Json;
using HardkorowyKodsu.Backend.Tables.DataAccess.Entities;
using HardkorowyKodsu.Backend.Tables.Dto;
using HardkorowyKodsu.Tables.Interfaces;

namespace HardkorowyKodsu.Tables;

internal class TablesBackendClient : ITablesBackendClient
{
	private readonly IHttpClientFactory mHttpClientFactory;

	public TablesBackendClient(IHttpClientFactory httpClientFactory)
	{
		mHttpClientFactory = httpClientFactory;
	}

	public async Task<IEnumerable<GetTablesReturnDto>> GetTablesAsync(CancellationToken cancellationToken)
	{
		using(var httpClient = mHttpClientFactory.CreateClient(HttpClientNames.Backend))
		{
			var response = await httpClient.GetAsync("/api/Tables", cancellationToken);
			response.EnsureSuccessStatusCode();

			return await response.Content.ReadFromJsonAsync<IEnumerable<GetTablesReturnDto>>(cancellationToken);
		}
	}

	public async Task<GetTableReturnDto> GetTableDetailsAsync(int tableId, CancellationToken cancellationToken)
	{
		using(var httpClient = mHttpClientFactory.CreateClient(HttpClientNames.Backend))
		{
			var response = await httpClient.GetAsync($"/api/Table/{tableId}", cancellationToken);
			response.EnsureSuccessStatusCode();

			return await response.Content.ReadFromJsonAsync<GetTableReturnDto>(cancellationToken);
		}
	}
}
