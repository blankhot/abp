using Abp.AspNetCore.Mvc.Views;

namespace Platform.Web.Views
{
    public abstract class PlatformRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected PlatformRazorPage()
        {
            LocalizationSourceName = PlatformConsts.LocalizationSourceName;
        }
    }
}
