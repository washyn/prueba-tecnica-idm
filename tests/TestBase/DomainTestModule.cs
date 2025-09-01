using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace TestBase;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpTestBaseModule))]
public class AppTestBaseModule : AbpModule
{
}
