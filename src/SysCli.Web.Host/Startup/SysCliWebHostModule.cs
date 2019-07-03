using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SysCli.Configuration;

namespace SysCli.Web.Host.Startup
{
    [DependsOn(
       typeof(SysCliWebCoreModule))]
    public class SysCliWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SysCliWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SysCliWebHostModule).GetAssembly());
        }
    }
}
