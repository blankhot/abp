using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.Common
{
    public class HttpContext
    {
        /// <summary>
        /// .NET Core Http对象接口
        /// </summary>
        private static IHttpContextAccessor _accessor;

        /// <summary>
        /// 当前http内容
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Current => _accessor.HttpContext;

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="accessor"></param>
        internal static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        /// <summary>
        /// 获取参数JSON字符串
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetQueryJsonStr(Microsoft.AspNetCore.Http.HttpContext context)
        {
            string query = string.Empty;
            if (context.Request.Query != null && context.Request.Query.Count > 0)
            {
                var dic = new Dictionary<string, dynamic>();
                foreach (var item in context.Request.Query)
                {
                    dic.Add(item.Key, item.Value.Count == 1 ? (dynamic)item.Value[0] : (dynamic)item.Value);
                }
                query = JsonOperator.JsonSerialize(dic);
            }
            return query;
        }

    }
}
