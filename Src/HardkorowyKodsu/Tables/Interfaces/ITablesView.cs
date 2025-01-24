using HardkorowyKodsu.Tables.CustomEventArgs;
using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables.Interfaces;

internal interface ITablesView
{
	event EventHandler DataLoadingRequested;
	event EventHandler<TableSelectionChangedEventArgs> TableSelectionChanged;

	bool DataLoadingButtonEnabled { set; }
	bool TableListEnabled { set; }
	bool ColumnListEnabled { set; }
	
	TableViewModel SelectedTable { get; set; }

	void SetInfoStatusMessage(string message);
	void SetErrorStatusMessage(string message);

	void ShowTables(ICollection<TableViewModel> tables);
	void ShowColumns(ICollection<ColumnViewModel> columns);
}
