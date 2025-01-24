using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables.CustomEventArgs;

public class TableSelectionChangedEventArgs : EventArgs
{
	public TableSelectionChangedEventArgs(TableViewModel selectedViewModel)
	{
		SelectedTable = selectedViewModel;
	}

	public TableViewModel SelectedTable { get; }
}
