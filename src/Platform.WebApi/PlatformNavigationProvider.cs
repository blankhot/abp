using Abp.Application.Navigation;
using Abp.Localization;

namespace Platform.WebApi
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class PlatformNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
