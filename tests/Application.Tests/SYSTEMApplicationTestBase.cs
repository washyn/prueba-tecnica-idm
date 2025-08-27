using Domain.Tests;
using Volo.Abp.Modularity;

namespace ERP.SYSTEM;

// public abstract class SYSTEMApplicationTestBase<TStartupModule> : AppTestBase<TStartupModule>
//     where TStartupModule : IAbpModule
// {
//
// }

public abstract class SYSTEMApplicationTestBase : AppTestBase<SYSTEMApplicationTestModule>
{

}
