using Infraestructure.Tests;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using Washyn.Kfc;

namespace Domain.Tests;

[DependsOn(typeof(InfraestructureTestModule))]
public class DomainTestModule : AbpModule
{
}
