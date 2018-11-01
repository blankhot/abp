using Platform.Common.DtoTool;
using Platform.Common.Helper;
using Platform.Entity;
using Platform.Enums;
using Platform.IRepositories;
using Platform.UserService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.UserService
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }   

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResponseResultModel<UserPageOutput>> GetUserAsync(UserPageInput input)
        {
            ResponseResultModel<UserPageOutput> ReturnObj = new ResponseResultModel<UserPageOutput>()
            {
                ResultStatus = ResponseStatus.OK,
                Data = new UserPageOutput()
            };

            try
            {
                if (ReturnObj.ResultStatus == ResponseStatus.OK)
                {
                    List<User> list = await _userRepository.GetAllListAsync(o => o.IsDelete == (int)IsDeleteStatus.No);
                    if (!string.IsNullOrEmpty(input.Name))
                    {
                        list = list.Where(o => o.RealName.Contains(input.Name)).ToList();
                    }
                    //分页
                    int TotalCount = list.Count;
                    list = list.OrderByDescending(m => m.CreateTime).Take(input.Limit * input.Page).Skip(input.Limit * (input.Page - 1)).ToList();
                    List<UserDto> adminDtos = MapperHelper.ResultData<List<UserDto>, List<User>>(list);

                    UserPageOutput infoOutput = new UserPageOutput()
                    {
                        Data = adminDtos,
                        Count = TotalCount
                    };
                    ReturnObj.Data = infoOutput;
                }
            }
            catch (Exception ex)
            {
                ReturnObj.ResponseErrorResult(null);
                return ReturnObj;
            }
            return ReturnObj.SetData();
        }
    }
}
