using Abp.Modules;
using Abp.Reflection.Extensions;
using TestProject.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TestProject.Web.Host.Startup
{
    [DependsOn(
       typeof(TestProjectWebCoreModule))]
    public class TestProjectWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TestProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestProjectWebHostModule).GetAssembly());
        }
    }
}
