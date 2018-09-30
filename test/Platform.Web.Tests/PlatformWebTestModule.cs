using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Platform.Web.Startup;
namespace Platform.Web.Tests
{
    [DependsOn(
        typeof(PlatformWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class PlatformWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformWebTestModule).GetAssembly());
        }
    }
}