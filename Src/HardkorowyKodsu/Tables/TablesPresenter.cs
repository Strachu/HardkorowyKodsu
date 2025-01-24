using AutoMapper;
using HardkorowyKodsu.Tables.CustomEventArgs;
using HardkorowyKodsu.Tables.Interfaces;
using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables;

internal class TablesPresenter
{
	private readonly ITablesView mTablesView;
	private readonly ITablesBackendClient mBackendClient;
	private readonly IMapper mMapper;

	private TableViewModel mCurrentlyShownTable;
	private CancellationTokenSource mPendingOperationCancellationToken = new CancellationTokenSource();

	public TablesPresenter(ITablesView tablesView, ITablesBackendClient backendClient, IMapper mapper)
	{
		mTablesView = tablesView;
		mBackendClient = backendClient;
		mMapper = mapper;

		mTablesView.DataLoadingRequested += DataLoadingRequested;
		mTablesView.TableSelectionChanged += TableSelectionChanged;
	}

	private async void DataLoadingRequested(object sender, EventArgs e)
	{
		mTablesView.DataLoadingButtonEnabled = false;
		mTablesView.TableListEnabled = false;

		mTablesView.SetInfoStatusMessage(Resources.StatusMessage_Loading);

		try
		{
			mPendingOperationCancellationToken.Cancel();
			mPendingOperationCancellationToken = new CancellationTokenSource();
			var currentOperationToken = mPendingOperationCancellationToken.Token;

			var previousSelectedModel = mTablesView.SelectedTable;

			var tables = await mBackendClient.GetTablesAsync(currentOperationToken);
			var tablesViewModel = mMapper.Map<List<TableViewModel>>(tables);

			if(!currentOperationToken.IsCancellationRequested)
			{
				mTablesView.SelectedTable = null;
				mTablesView.ShowTables(tablesViewModel);

				mTablesView.SetInfoStatusMessage(string.Empty);
				mTablesView.TableListEnabled = true;

				if(previousSelectedModel != null)
				{
					var modelToSelect = tablesViewModel.SingleOrDefault(x => x.TableId == previousSelectedModel.TableId);
					if(modelToSelect != null)
					{
						mTablesView.SelectedTable = modelToSelect;
					}
				}
			}
		}
		catch(OperationCanceledException)
		{
			return;
		}
		catch
		{
			mTablesView.SetErrorStatusMessage(Resources.StatusMessage_Failed);
		}

		mTablesView.DataLoadingButtonEnabled = true;
	}

	private async void TableSelectionChanged(object sender, TableSelectionChangedEventArgs e)
	{
		if(e.SelectedTable == null || mCurrentlyShownTable?.TableId == e.SelectedTable.TableId)
		{
			return;
		}

		// TODO Do that only 200ms after the selection of last item so that continuous navigation with arrows doesn't slow down

		mTablesView.ColumnListEnabled = false;
		mTablesView.SetInfoStatusMessage(Resources.StatusMessage_Loading);

		try
		{
			mPendingOperationCancellationToken.Cancel();
			mPendingOperationCancellationToken = new CancellationTokenSource();
			var currentOperationToken = mPendingOperationCancellationToken.Token;

			var tableDetails = await mBackendClient.GetTableDetailsAsync(e.SelectedTable.TableId, mPendingOperationCancellationToken.Token);
			var columnsViewModel = mMapper.Map<List<ColumnViewModel>>(tableDetails.Columns);

			if(!currentOperationToken.IsCancellationRequested)
			{
				mTablesView.ShowColumns(columnsViewModel);

				mTablesView.SetInfoStatusMessage(string.Empty);

				mCurrentlyShownTable = e.SelectedTable;
			}
		}
		catch(OperationCanceledException)
		{
			return;
		}
		catch
		{
			mTablesView.ShowColumns([]);
			mTablesView.SetErrorStatusMessage(Resources.StatusMessage_Failed);
		}

		mTablesView.ColumnListEnabled = true;
	}
}
