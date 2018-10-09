using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Platform.WebApi.Controllers
{
    [Route("api/[controller]")]
    [DontWrapResult]
    public abstract class BaseController : AbpController
    {
        public BaseController()
        {
            
        }
    }
}