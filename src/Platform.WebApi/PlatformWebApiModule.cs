using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Platform.Configuration;
using Platform.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Platform.WebApi
{
    [DependsOn(
        typeof(PlatformApplicationModule), 
        typeof(PlatformEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class PlatformWebApiModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PlatformWebApiModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(PlatformConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<PlatformNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(PlatformApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformWebApiModule).GetAssembly());
        }
    }
}