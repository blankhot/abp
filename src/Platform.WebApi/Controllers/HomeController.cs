using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Platform.WebApi.Controllers
{
    /// <summary>
    /// 默认控制器
    /// </summary>
    [Route("~/")]
    [HiddenApi]
    public class HomeController : AbpController
    {
        /// <summary>
        /// 首页
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("~/swagger/index.html");
        }

    }
}