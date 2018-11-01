using Platform.Common.DtoTool;
using Platform.UserService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Platform.UserService
{
    public interface IUserService: IBaseService
    {
        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ResponseResultModel<UserPageOutput>> GetUserAsync(UserPageInput input);
    }
}
