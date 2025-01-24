using HardkorowyKodsu.Tables;

namespace HardkorowyKoksu;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		ApplicationConfiguration.Initialize();

		// TODO MainFormPresenter
		var mainForm = new MainForm();
		var tablesPresenter = new TablesPresenter(mainForm.TablesPanel);

		Application.Run(mainForm);
	}
}