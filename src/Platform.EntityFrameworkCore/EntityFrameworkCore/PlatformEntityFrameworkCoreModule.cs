using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Platform.EntityFrameworkCore
{
    [DependsOn(
        typeof(PlatformCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class PlatformEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformEntityFrameworkCoreModule).GetAssembly());
        }
    }
}