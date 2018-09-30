using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Platform
{
    /// <summary>
    /// 模块定义类
    /// </summary>
    [DependsOn(
        typeof(PlatformCoreModule),
        typeof(AbpAutoMapperModule))]
    public class PlatformApplicationModule : AbpModule
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformApplicationModule).GetAssembly());
        }

        /// <summary>
        /// 预加载
        /// </summary>
        public override void PreInitialize()
        {
            //配置初始化
            //MarketInterceptorRegistrar.Initialize(IocManager.IocContainer.Kernel);
        }
    }
}