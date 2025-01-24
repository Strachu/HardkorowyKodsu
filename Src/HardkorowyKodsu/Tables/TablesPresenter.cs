using HardkorowyKodsu.Tables.Interfaces;

namespace HardkorowyKodsu.Tables;

internal class TablesPresenter
{
	private readonly ITablesView mTablesView;

	public TablesPresenter(ITablesView tablesView)
	{
		mTablesView = tablesView;

		mTablesView.DataLoadingRequested += DataLoadingRequested;
	}

	private void DataLoadingRequested(object sender, EventArgs e)
	{
		mTablesView.DataLoadingButtonEnabled = false;
	}

	public void Show()
	{

	}
}
