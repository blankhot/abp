using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Platform.Configuration;
using Platform.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Platform.Web.Startup
{
    [DependsOn(
        typeof(PlatformApplicationModule), 
        typeof(PlatformEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class PlatformWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PlatformWebModule(IHostingEnvironment env)
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
            IocManager.RegisterAssemblyByConvention(typeof(PlatformWebModule).GetAssembly());
        }
    }
}