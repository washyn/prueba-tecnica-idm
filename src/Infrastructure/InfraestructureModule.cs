using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace Washyn.Kfc
{
    [DependsOn(typeof(DomainModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreSqliteModule))]
    public class InfrastructureModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AppDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlite();
            });
        }
    }
}