using Infraestructure.Tests;
using Volo.Abp.Modularity;
using Washyn.Kfc;

namespace Application.Tests;

[DependsOn(typeof(ApplicationModule))]
[DependsOn(typeof(InfraestructureTestModule))]
public class ApplicationTestModule : AbpModule
{
}
