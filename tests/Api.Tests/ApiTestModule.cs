using Application.Tests;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Modularity;
using Washyn.Kfc;

namespace Api.Tests;

[DependsOn(typeof(AbpAspNetCoreTestBaseModule))]
[DependsOn(typeof(ApiModule))]
[DependsOn(typeof(ApplicationTestModule))]
public class ApiTestModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<IMvcBuilder>(builder =>
        {
            builder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(ApiModule).Assembly));
        });
    }
}
