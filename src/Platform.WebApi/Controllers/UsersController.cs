using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Platform.Attributes;
using Platform.Common.DtoTool;
using Platform.UserService;
using Platform.UserService.Dtos;

namespace Platform.WebApi.Controllers
{
    /// <summary>
    /// 用户信息接口
    /// </summary>
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsersController : BaseController
    {
        /// <summary>
        /// 用户服务层
        /// </summary>
        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("GetUserAsync")]
        public async Task<ResponseResultModel<UserPageOutput>> GetUserAsync([FromBody]UserPageInput input)
        {
            return await _userService.GetUserAsync(input);
        }

        /// <summary>
        /// 测试一
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("GetUserAsync1"),Anonymous]
        public async Task<ResponseResultModel<UserPageOutput>> GetUserAsync1([FromBody]UserPageInput input)
        {
            return await _userService.GetUserAsync(input);
        }

        /// <summary>
        /// 测试二
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("GetUserAsync2"),Anonymous,ApiExplorerSettings(GroupName = PlatformConsts.ManageName)]
        public async Task<ResponseResultModel<UserPageOutput>> GetUserAsync2([FromBody]UserPageInput input)
        {
            return await _userService.GetUserAsync(input);
        }
    }
}