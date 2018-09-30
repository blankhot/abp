using Abp.AspNetCore.Mvc.Controllers;

namespace Platform.Web.Controllers
{
    public abstract class PlatformControllerBase: AbpController
    {
        protected PlatformControllerBase()
        {
            LocalizationSourceName = PlatformConsts.LocalizationSourceName;
        }
    }
}