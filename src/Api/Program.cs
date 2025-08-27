using Serilog;
using Volo.Abp.Data;

namespace Washyn.Kfc;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var loggerConfiguration = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.log", rollingInterval: RollingInterval.Day, shared: true))
            .WriteTo.Async(c => c.Console());

        Log.Logger = loggerConfiguration.CreateLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            if (IsMigrateDatabase(args))
            {
                builder.Services.AddDataMigrationEnvironment();
            }
            await builder.AddApplicationAsync<ApiModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();

            if (IsMigrateDatabase(args))
            {
                // await app.Services.GetRequiredService<LotDbMigrationService>().MigrateAsync();
                return 0;
            }

            Log.Information("Starting app.");
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "App terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    // TODO: remover si no es necesario
    private static bool IsMigrateDatabase(string[] args)
    {
        return args.Any(x => x.Contains("--migrate-database", StringComparison.OrdinalIgnoreCase));
    }
}