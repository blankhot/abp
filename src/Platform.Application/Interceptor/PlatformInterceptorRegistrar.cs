using Abp.Application.Services;
using Castle.Core;
using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.Interceptor
{
    public static class PlatformInterceptorRegistrar
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="kernel"></param>
        public static void Initialize(IKernel kernel)
        {
            //注册拦截器
            kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        /// <summary>
        /// 拦截器方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        private static void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            if (typeof(IApplicationService).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add
                (new InterceptorReference(typeof(PlatformInterceptor)));
            }
        }
    }
}
