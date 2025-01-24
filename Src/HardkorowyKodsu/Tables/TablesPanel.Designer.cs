namespace HardkorowyKodsu.Tables;

partial class TablesPanel
{
	/// <summary> 
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary> 
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if(disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Component Designer generated code

	/// <summary> 
	/// Required method for Designer support - do not modify 
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		TableLayoutPanel MainTableLayoutPanel;
		TableLayoutPanel ControlPanel;
		GroupBox TablesGroupBox;
		GroupBox ColumnsGroupBox;
		var dataGridViewCellStyle1 = new DataGridViewCellStyle();
		var dataGridViewCellStyle4 = new DataGridViewCellStyle();
		var dataGridViewCellStyle2 = new DataGridViewCellStyle();
		var dataGridViewCellStyle3 = new DataGridViewCellStyle();
		mLoadDataButton = new Button();
		mStatusLabel = new Label();
		splitContainer1 = new SplitContainer();
		mTablesListBox = new ListBox();
		mColumnsDataGridView = new DataGridView();
		mColumnNameDataGridViewColumn = new DataGridViewTextBoxColumn();
		mTypeNameDataGridViewColumn = new DataGridViewTextBoxColumn();
		mNotNullDataGridViewColumn = new DataGridViewCheckBoxColumn();
		MainTableLayoutPanel = new TableLayoutPanel();
		ControlPanel = new TableLayoutPanel();
		TablesGroupBox = new GroupBox();
		ColumnsGroupBox = new GroupBox();
		MainTableLayoutPanel.SuspendLayout();
		ControlPanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
		splitContainer1.Panel1.SuspendLayout();
		splitContainer1.Panel2.SuspendLayout();
		splitContainer1.SuspendLayout();
		TablesGroupBox.SuspendLayout();
		ColumnsGroupBox.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)mColumnsDataGridView).BeginInit();
		SuspendLayout();
		// 
		// MainTableLayoutPanel
		// 
		MainTableLayoutPanel.ColumnCount = 1;
		MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		MainTableLayoutPanel.Controls.Add(ControlPanel, 0, 0);
		MainTableLayoutPanel.Controls.Add(splitContainer1, 0, 1);
		MainTableLayoutPanel.Dock = DockStyle.Fill;
		MainTableLayoutPanel.Location = new Point(0, 0);
		MainTableLayoutPanel.Name = "MainTableLayoutPanel";
		MainTableLayoutPanel.RowCount = 2;
		MainTableLayoutPanel.RowStyles.Add(new RowStyle());
		MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		MainTableLayoutPanel.Size = new Size(600, 600);
		MainTableLayoutPanel.TabIndex = 2;
		// 
		// ControlPanel
		// 
		ControlPanel.AutoSize = true;
		ControlPanel.ColumnCount = 2;
		ControlPanel.ColumnStyles.Add(new ColumnStyle());
		ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		ControlPanel.Controls.Add(mLoadDataButton, 0, 0);
		ControlPanel.Controls.Add(mStatusLabel, 1, 0);
		ControlPanel.Dock = DockStyle.Fill;
		ControlPanel.Location = new Point(3, 3);
		ControlPanel.Name = "ControlPanel";
		ControlPanel.RowCount = 1;
		ControlPanel.RowStyles.Add(new RowStyle());
		ControlPanel.Size = new Size(594, 31);
		ControlPanel.TabIndex = 1;
		// 
		// mLoadDataButton
		// 
		mLoadDataButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		mLoadDataButton.AutoSize = true;
		mLoadDataButton.Location = new Point(20, 3);
		mLoadDataButton.Margin = new Padding(20, 3, 20, 3);
		mLoadDataButton.Name = "mLoadDataButton";
		mLoadDataButton.Size = new Size(85, 25);
		mLoadDataButton.TabIndex = 0;
		mLoadDataButton.Text = "Pobierz dane";
		mLoadDataButton.UseVisualStyleBackColor = true;
		mLoadDataButton.Click += mLoadDataButton_Click;
		// 
		// mStatusLabel
		// 
		mStatusLabel.AutoEllipsis = true;
		mStatusLabel.Dock = DockStyle.Fill;
		mStatusLabel.Location = new Point(128, 0);
		mStatusLabel.Name = "mStatusLabel";
		mStatusLabel.Size = new Size(463, 31);
		mStatusLabel.TabIndex = 1;
		mStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
		// 
		// splitContainer1
		// 
		splitContainer1.Dock = DockStyle.Fill;
		splitContainer1.Location = new Point(3, 40);
		splitContainer1.Name = "splitContainer1";
		// 
		// splitContainer1.Panel1
		// 
		splitContainer1.Panel1.Controls.Add(TablesGroupBox);
		// 
		// splitContainer1.Panel2
		// 
		splitContainer1.Panel2.Controls.Add(ColumnsGroupBox);
		splitContainer1.Size = new Size(594, 557);
		splitContainer1.SplitterDistance = 272;
		splitContainer1.TabIndex = 0;
		// 
		// TablesGroupBox
		// 
		TablesGroupBox.Controls.Add(mTablesListBox);
		TablesGroupBox.Dock = DockStyle.Fill;
		TablesGroupBox.Location = new Point(0, 0);
		TablesGroupBox.Name = "TablesGroupBox";
		TablesGroupBox.Size = new Size(272, 557);
		TablesGroupBox.TabIndex = 0;
		TablesGroupBox.TabStop = false;
		TablesGroupBox.Text = "Tabele i widoki";
		// 
		// mTablesListBox
		// 
		mTablesListBox.Dock = DockStyle.Fill;
		mTablesListBox.Enabled = false;
		mTablesListBox.FormattingEnabled = true;
		mTablesListBox.ItemHeight = 15;
		mTablesListBox.Location = new Point(3, 19);
		mTablesListBox.Name = "mTablesListBox";
		mTablesListBox.Size = new Size(266, 535);
		mTablesListBox.TabIndex = 0;
		mTablesListBox.SelectedValueChanged += mTablesListBox_SelectedValueChanged;
		// 
		// ColumnsGroupBox
		// 
		ColumnsGroupBox.Controls.Add(mColumnsDataGridView);
		ColumnsGroupBox.Dock = DockStyle.Fill;
		ColumnsGroupBox.Location = new Point(0, 0);
		ColumnsGroupBox.Name = "ColumnsGroupBox";
		ColumnsGroupBox.Size = new Size(318, 557);
		ColumnsGroupBox.TabIndex = 0;
		ColumnsGroupBox.TabStop = false;
		ColumnsGroupBox.Text = "Kolumny";
		// 
		// mColumnsDataGridView
		// 
		mColumnsDataGridView.AllowUserToAddRows = false;
		mColumnsDataGridView.AllowUserToDeleteRows = false;
		mColumnsDataGridView.AllowUserToOrderColumns = true;
		mColumnsDataGridView.AllowUserToResizeRows = false;
		dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle1.BackColor = SystemColors.Control;
		dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
		dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
		mColumnsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
		mColumnsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		mColumnsDataGridView.Columns.AddRange(new DataGridViewColumn[] { mColumnNameDataGridViewColumn, mTypeNameDataGridViewColumn, mNotNullDataGridViewColumn });
		mColumnsDataGridView.Dock = DockStyle.Fill;
		mColumnsDataGridView.Enabled = false;
		mColumnsDataGridView.Location = new Point(3, 19);
		mColumnsDataGridView.Name = "mColumnsDataGridView";
		mColumnsDataGridView.ReadOnly = true;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		mColumnsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
		mColumnsDataGridView.RowHeadersVisible = false;
		mColumnsDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
		mColumnsDataGridView.Size = new Size(312, 535);
		mColumnsDataGridView.TabIndex = 0;
		// 
		// mColumnNameDataGridViewColumn
		// 
		mColumnNameDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		mColumnNameDataGridViewColumn.DefaultCellStyle = dataGridViewCellStyle2;
		mColumnNameDataGridViewColumn.HeaderText = "Nazwa";
		mColumnNameDataGridViewColumn.Name = "mColumnNameDataGridViewColumn";
		mColumnNameDataGridViewColumn.ReadOnly = true;
		// 
		// mTypeNameDataGridViewColumn
		// 
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		mTypeNameDataGridViewColumn.DefaultCellStyle = dataGridViewCellStyle3;
		mTypeNameDataGridViewColumn.HeaderText = "Typ";
		mTypeNameDataGridViewColumn.Name = "mTypeNameDataGridViewColumn";
		mTypeNameDataGridViewColumn.ReadOnly = true;
		// 
		// mNotNullDataGridViewColumn
		// 
		mNotNullDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		mNotNullDataGridViewColumn.HeaderText = "NOT NULL";
		mNotNullDataGridViewColumn.Name = "mNotNullDataGridViewColumn";
		mNotNullDataGridViewColumn.ReadOnly = true;
		mNotNullDataGridViewColumn.Width = 68;
		// 
		// TablesPanel
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		Controls.Add(MainTableLayoutPanel);
		Name = "TablesPanel";
		Size = new Size(600, 600);
		MainTableLayoutPanel.ResumeLayout(false);
		MainTableLayoutPanel.PerformLayout();
		ControlPanel.ResumeLayout(false);
		ControlPanel.PerformLayout();
		splitContainer1.Panel1.ResumeLayout(false);
		splitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
		splitContainer1.ResumeLayout(false);
		TablesGroupBox.ResumeLayout(false);
		ColumnsGroupBox.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)mColumnsDataGridView).EndInit();
		ResumeLayout(false);
	}

	#endregion
	private SplitContainer splitContainer1;
	private GroupBox TablesGroupBox;
	private GroupBox ColumnsGroupBox;
	private Button mLoadDataButton;
	private Label mStatusLabel;
	private ListBox mTablesListBox;
	private DataGridView mColumnsDataGridView;
	private DataGridViewTextBoxColumn mColumnNameDataGridViewColumn;
	private DataGridViewTextBoxColumn mTypeNameDataGridViewColumn;
	private DataGridViewCheckBoxColumn mNotNullDataGridViewColumn;
}
