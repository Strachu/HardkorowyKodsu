using HardkorowyKodsu.Tables.CustomEventArgs;
using HardkorowyKodsu.Tables.Interfaces;
using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables;

public partial class TablesPanel : UserControl, ITablesView
{
	private readonly Color mOriginalDataGridColor;

	public TablesPanel()
	{
		InitializeComponent();

		mTablesListBox.DisplayMember = nameof(TableViewModel.DisplayName);

		mColumnsDataGridView.AutoGenerateColumns = false;
		mColumnNameDataGridViewColumn.DataPropertyName = nameof(ColumnViewModel.ColumnName);
		mTypeNameDataGridViewColumn.DataPropertyName = nameof(ColumnViewModel.TypeName);
		mNotNullDataGridViewColumn.DataPropertyName = nameof(ColumnViewModel.IsNotNull);

		mOriginalDataGridColor = mColumnsDataGridView.ForeColor;
	}

	public event EventHandler DataLoadingRequested;
	public event EventHandler<TableSelectionChangedEventArgs> TableSelectionChanged;

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
			mColumnsDataGridView.ForeColor = value ? mOriginalDataGridColor : SystemColors.GrayText;
		}
	}

	public bool DataLoadingButtonEnabled
	{
		set
		{
			mLoadDataButton.Enabled = value;
		}
	}

	public TableViewModel SelectedTable
	{
		get
		{
			return (TableViewModel)mTablesListBox.SelectedItem;
		}

		set
		{
			mTablesListBox.SelectedItem = value;
		}
	}

	private void mLoadDataButton_Click(object sender, EventArgs e)
	{
		DataLoadingRequested?.Invoke(this, EventArgs.Empty);
	}

	private void mTablesListBox_SelectedValueChanged(object sender, EventArgs e)
	{
		TableSelectionChanged?.Invoke(this, new TableSelectionChangedEventArgs(SelectedTable));
	}
	
	public void SetInfoStatusMessage(string message)
	{
		mStatusLabel.Text = message;
		mStatusLabel.ForeColor = Color.Black;
	}

	public void SetErrorStatusMessage(string message)
	{
		mStatusLabel.Text = message;
		mStatusLabel.ForeColor = Color.Red;
	}

	public void ShowTables(ICollection<TableViewModel> tables)
	{
		// Disable auto selection of first entry
		mTablesListBox.SelectionMode = SelectionMode.None;

		mTablesListBox.DataSource = tables;

		mTablesListBox.SelectionMode = SelectionMode.One;
	}

	public void ShowColumns(ICollection<ColumnViewModel> columns)
	{
		mColumnsDataGridView.DataSource = columns;
	}
}
