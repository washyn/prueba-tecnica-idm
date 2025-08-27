﻿using Volo.Abp.Modularity;

namespace Domain.Tests;

/* Inherit from this class for your domain layer tests. */
public abstract class AppDomainTestBase<TStartupModule> : AppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
