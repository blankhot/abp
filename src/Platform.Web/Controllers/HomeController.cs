using Microsoft.AspNetCore.Mvc;

namespace Platform.Web.Controllers
{
    public class HomeController : PlatformControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}