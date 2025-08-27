using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Washyn.Kfc
{
    public class EntityFrameworkCoreDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Api/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(configuration.GetConnectionString("Default"));
            return new AppDbContext(builder.Options);
        }
    }
}