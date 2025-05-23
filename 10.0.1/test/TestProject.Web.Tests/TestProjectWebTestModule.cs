﻿using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestProject.EntityFrameworkCore;
using TestProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TestProject.Web.Tests;

[DependsOn(
    typeof(TestProjectWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class TestProjectWebTestModule : AbpModule
{
    public TestProjectWebTestModule(TestProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(TestProjectWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(TestProjectWebMvcModule).Assembly);
    }
}