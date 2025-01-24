using HardkorowyKodsu.Tables.Interfaces;

namespace HardkorowyKodsu.Tables;

public partial class TablesPanel : UserControl, ITablesView
{
	public TablesPanel()
	{
		InitializeComponent();
	}

	public bool TableListEnabled
	{
		set
		{
			mTablesListBox.Enabled = value;
		}
	}

	public bool ColumnListEnabled
	{
		set
		{
			mColumnsDataGridView.Enabled = value;
		}
	}

	public bool DataLoadingButtonEnabled
	{
		set
		{
			mLoadDataButton.Enabled = value;
		}
	}

	public event EventHandler DataLoadingRequested;

	private void mLoadDataButton_Click(object sender, EventArgs e)
	{
		DataLoadingRequested?.Invoke(this, EventArgs.Empty);
	}
}
