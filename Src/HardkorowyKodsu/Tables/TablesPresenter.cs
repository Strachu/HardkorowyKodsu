using HardkorowyKodsu.Tables.Interfaces;

namespace HardkorowyKodsu.Tables;

internal class TablesPresenter
{
	private readonly ITablesView mTablesView;
	private readonly ITablesBackendClient mBackendClient;

	public TablesPresenter(ITablesView tablesView, ITablesBackendClient backendClient)
	{
		mTablesView = tablesView;
		mBackendClient = backendClient;

		mTablesView.DataLoadingRequested += DataLoadingRequested;
	}

	private async void DataLoadingRequested(object sender, EventArgs e)
	{
		mTablesView.DataLoadingButtonEnabled = false;

		await mBackendClient.GetTablesAsync(CancellationToken.None);

		mTablesView.DataLoadingButtonEnabled = true;
	}

	public void Show()
	{

	}
}
