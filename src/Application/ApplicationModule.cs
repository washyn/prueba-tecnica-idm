using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace Washyn.Kfc
{
    [DependsOn(typeof(DomainModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(AbpFluentValidationModule))]
    public class ApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ApplicationModule>();
            });
        }
    }
}
