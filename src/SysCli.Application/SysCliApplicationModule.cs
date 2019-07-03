using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SysCli.Authorization;

namespace SysCli
{
    [DependsOn(
        typeof(SysCliCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SysCliApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SysCliAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SysCliApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
