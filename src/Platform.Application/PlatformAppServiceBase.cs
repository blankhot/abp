using Abp.Application.Services;

namespace Platform
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class PlatformAppServiceBase : ApplicationService
    {
        protected PlatformAppServiceBase()
        {
            LocalizationSourceName = PlatformConsts.LocalizationSourceName;
        }
    }
}