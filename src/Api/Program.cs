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

            await builder.AddApplicationAsync<ApiModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();

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
}