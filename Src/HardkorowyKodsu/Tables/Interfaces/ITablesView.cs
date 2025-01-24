using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables.Interfaces;

internal interface ITablesView
{
	event EventHandler DataLoadingRequested;

	bool DataLoadingButtonEnabled { set; }
	bool TableListEnabled { set; }
	bool ColumnListEnabled { set; }

	void ShowTables(ICollection<TableViewModel> tables);
	void ShowColumns(ICollection<ColumnViewModel> columns);
}
