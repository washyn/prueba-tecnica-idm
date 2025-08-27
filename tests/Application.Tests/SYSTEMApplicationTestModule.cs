using ERP.SYSTEM.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Washyn.Kfc;

namespace ERP.SYSTEM;

[DependsOn(typeof(ApplicationModule))]
[DependsOn(typeof(SYSTEMEntityFrameworkCoreTestModule))]
public class SYSTEMApplicationTestModule : AbpModule
{
}
