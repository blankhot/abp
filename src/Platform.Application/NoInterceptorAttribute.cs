using System;
using System.Collections.Generic;
using System.Text;

namespace Platform
{
    /// <summary>
    /// 特性=不拦截
    /// wanglq
    /// 2018-9-21
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class NoInterceptorAttribute : Attribute
    {

    }
}
