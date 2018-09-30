using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Platform.Common
{
    public static class StaticHttpContextExtensions
    {
        /// <summary>
        /// 服务注入方法
        /// </summary>
        /// <param name="services"></param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// 使用注册方法（用于Startup)
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
        {
            //获取服务
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            //注入
            HttpContext.Configure(httpContextAccessor);
            return app;
        }
    }
}
