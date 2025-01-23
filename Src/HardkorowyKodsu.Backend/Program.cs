using HardkorowyKodsu.Backend.Infrastructure;
using HardkorowyKodsu.Backend.Infrastructure.Interfaces;
using HardkorowyKodsu.Backend.Tables.DataAccess;
using HardkorowyKodsu.Backend.Tables.DataAccess.Interfaces;
using HardkorowyKodsu.Backend.Tables.MappingProfiles;

namespace HardkorowyKodsu.Backend;

public static class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		ConfigureServices(builder.Services);

		var app = builder.Build();

		if(app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}

	private static void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		services.AddAutoMapper(typeof(GetTablesReturnDtoProfile).Assembly);

		services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();
		services.AddSingleton<ITablesDao, TablesDao>();
	}
}
