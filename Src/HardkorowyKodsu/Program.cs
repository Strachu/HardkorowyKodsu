using HardkorowyKodsu.Tables;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using HardkorowyKodsu.Tables.Interfaces;
using HardkorowyKodsu;

namespace HardkorowyKoksu;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		ApplicationConfiguration.Initialize();

		var configuration = ConfigureAppConfiguration();
		var services = ConfigureServices(configuration);

		// TODO MainFormPresenter
		var mainForm = services.GetRequiredService<MainForm>();
		var tablesPresenter = services.GetRequiredService<TablesPresenter>();

		Application.Run(mainForm);
	}
	
	private static IConfiguration ConfigureAppConfiguration()
	{
		var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

		return new ConfigurationBuilder()
			.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
			.Build();
	}

	private static IServiceProvider ConfigureServices(IConfiguration configuration)
	{
		var services = new ServiceCollection();

		services.AddSingleton(configuration);

		services.AddHttpClient(HttpClientNames.Backend, x => x.BaseAddress = new Uri(configuration.GetValue<string>("BackendUrl")));

		services.AddSingleton<MainForm>();
		services.AddSingleton<ITablesView>(x => x.GetRequiredService<MainForm>().TablesPanel);

		services.AddSingleton<TablesPresenter>();

		services.AddSingleton<ITablesBackendClient, TablesBackendClient>();

		return services.BuildServiceProvider();
	}
}