using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Washyn.Kfc;

[DependsOn(typeof(AbpDddDomainModule))]
public class DomainModule : AbpModule
{
}