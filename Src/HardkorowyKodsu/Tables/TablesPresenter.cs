using AutoMapper;
using HardkorowyKodsu.Tables.Interfaces;
using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables;

internal class TablesPresenter
{
	private readonly ITablesView mTablesView;
	private readonly ITablesBackendClient mBackendClient;
	private readonly IMapper mMapper;

	public TablesPresenter(ITablesView tablesView, ITablesBackendClient backendClient, IMapper mapper)
	{
		mTablesView = tablesView;
		mBackendClient = backendClient;
		mMapper = mapper;

		mTablesView.DataLoadingRequested += DataLoadingRequested;
	}

	private async void DataLoadingRequested(object sender, EventArgs e)
	{
		mTablesView.DataLoadingButtonEnabled = false;

		var tables = await mBackendClient.GetTablesAsync(CancellationToken.None);
		var tablesViewModel = mMapper.Map<List<TableViewModel>>(tables);

		mTablesView.ShowTables(tablesViewModel);
		
		var tableDetails = await mBackendClient.GetTableDetailsAsync(tablesViewModel[5].TableId, CancellationToken.None);
		var columnsViewModel = mMapper.Map<List<ColumnViewModel>>(tableDetails.Columns);

		mTablesView.ShowColumns(columnsViewModel);

		mTablesView.DataLoadingButtonEnabled = true;
		mTablesView.ColumnListEnabled = true;
		mTablesView.TableListEnabled = true;
	}

	public void Show()
	{

	}
}
