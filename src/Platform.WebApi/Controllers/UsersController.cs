using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Platform.DtoTool;
using Platform.UserService;
using Platform.UserService.Dtos;

namespace Platform.WebApi.Controllers
{
    /// <summary>
    /// 用户信息接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("GetUserAsync")]
        public async Task<ResponseResultModel<UserPageOutput>> GetUserAsync(UserPageInput input)
        {
            return await _userService.GetUserAsync(input);
        }

    }
}
