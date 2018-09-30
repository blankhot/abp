using System.Threading.Tasks;
using Platform.Web.Controllers;
using Shouldly;
using Xunit;

namespace Platform.Web.Tests.Controllers
{
    public class HomeController_Tests: PlatformWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
