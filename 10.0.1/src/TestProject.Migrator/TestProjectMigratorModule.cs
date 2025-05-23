using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestProject.Configuration;
using TestProject.EntityFrameworkCore;
using TestProject.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace TestProject.Migrator;

[DependsOn(typeof(TestProjectEntityFrameworkModule))]
public class TestProjectMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public TestProjectMigratorModule(TestProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(TestProjectMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            TestProjectConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(TestProjectMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
