using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Platform.Common;
using Platform.DtoTool;
using Platform.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.WebApi
{
    /// <summary>
    /// 异常处理类
    /// </summary>
    public class MyExceptionFilter : IExceptionFilter, IAsyncExceptionFilter, IFilterMetadata
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {

            if (context.ExceptionHandled == false)
            {
                var result = new Result()
                {
                    Code = ResponseStatus.HandleError,
                    Time = DateTime.Now,
                    Message = context.Exception.Message
                };

                context.Result = new ContentResult
                {
                    Content = JsonOperator.JsonSerialize(result),
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "application/json"
                };
            }
            context.ExceptionHandled = true; //异常已处理了
        }
        /// <summary>
        /// 异步异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;

        }
    }
}
