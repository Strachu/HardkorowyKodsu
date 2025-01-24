using HardkorowyKodsu.Tables.Interfaces;
using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables;

public partial class TablesPanel : UserControl, ITablesView
{
	public TablesPanel()
	{
		InitializeComponent();
	}

	public event EventHandler DataLoadingRequested;

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



	private void mLoadDataButton_Click(object sender, EventArgs e)
	{
		DataLoadingRequested?.Invoke(this, EventArgs.Empty);
	}

	public void ShowTables(ICollection<TableViewModel> tables)
	{
		mTablesListBox.DataSource = tables;
		mTablesListBox.DisplayMember = nameof(TableViewModel.DisplayName);
	}

	public void ShowColumns(ICollection<ColumnViewModel> columns)
	{
		mColumnsDataGridView.AutoGenerateColumns = false;
		mColumnsDataGridView.DataSource = columns;

		mColumnNameDataGridViewColumn.DataPropertyName = nameof(ColumnViewModel.ColumnName);
		mTypeNameDataGridViewColumn.DataPropertyName = nameof(ColumnViewModel.TypeName);
		mNotNullDataGridViewColumn.DataPropertyName = nameof(ColumnViewModel.IsNotNull);
	}
}
