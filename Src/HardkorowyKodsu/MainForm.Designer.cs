namespace HardkorowyKoksu;

partial class MainForm
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
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

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		TablesPanel = new HardkorowyKodsu.Tables.TablesPanel();
		SuspendLayout();
		// 
		// TablesPanel
		// 
		TablesPanel.Dock = DockStyle.Fill;
		TablesPanel.Location = new Point(0, 0);
		TablesPanel.Name = "TablesPanel";
		TablesPanel.Size = new Size(584, 561);
		TablesPanel.TabIndex = 0;
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(584, 561);
		Controls.Add(TablesPanel);
		MinimumSize = new Size(300, 300);
		Name = "MainForm";
		Text = "HardkorowyKodsu";
		ResumeLayout(false);
	}

	#endregion

	internal HardkorowyKodsu.Tables.TablesPanel TablesPanel;
}
