using Domain.Tests;
using Volo.Abp.Modularity;
using Washyn.Kfc;

namespace Application.Tests;

[DependsOn(typeof(ApplicationModule))]
[DependsOn(typeof(DomainTestModule))]
public class ApplicationTestModule : AbpModule
{
}
