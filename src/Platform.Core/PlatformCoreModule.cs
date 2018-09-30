using Abp.Modules;
using Abp.Reflection.Extensions;
using Platform.Localization;

namespace Platform
{
    public class PlatformCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            PlatformLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformCoreModule).GetAssembly());
        }
    }
}