using Castle.Core;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Platform.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interceptor
{
    public class PlatformInterceptor: StandardInterceptor
    {
        /// <summary>
        /// 日志
        /// </summary>
        public ILogger Logger { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public PlatformInterceptor()
        {
            Logger = NullLogger.Instance;
        }
        /// <summary>
        /// 重写执行后方法
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PostProceed(IInvocation invocation)
        {
            try
            {
                ////执行原对象中的方法  
                //invocation.Proceed();

                var method = invocation.MethodInvocationTarget ?? invocation.Method;
                //对当前方法的特性验证
                var qNoAttribute = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(InterceptorAttribute)) as NoInterceptorAttribute;
                if (qNoAttribute == null)
                {
                    if (invocation.ReturnValue is Task)
                    {
                        var task = invocation.ReturnValue as Task;
                        //var awaiter = task.GetAwaiter();
                        //awaiter.GetResult();
                        task.Wait();
                        var result = invocation.ReturnValue as dynamic;
                        if (result.Result != null)
                            WriteLogInfo(invocation, result.Result);
                    }
                    else
                        WriteLogInfo(invocation, invocation.ReturnValue);
                }
            }
            catch (Exception ex)
            {
                AbpLogHelper.Error(ex);
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="result"></param>
        public void WriteLogInfo(IInvocation invocation, object result)
        {
            try
            {
                //接口方法名称
                string methodName = $"{invocation.MethodInvocationTarget.DeclaringType.FullName}.{invocation.Method.Name}";
                StringBuilder builder = new StringBuilder();
                var context = HttpContext.Current;
                builder.AppendFormat("【接口名】{0}", methodName);
                builder.AppendFormat("\r\n\r\n【IP地址】{0}", context == null ? string.Empty : context.Connection.RemoteIpAddress.ToString());
                builder.AppendFormat("\r\n\r\n【参数】{0}", JsonOperator.JsonSerialize(invocation.Arguments));
                builder.AppendFormat("\r\n\r\n【返回值】{0}", JsonOperator.JsonSerialize(result));//invocation.ReturnValue
                Logger.Error(builder.ToString());
            }
            catch (Exception ex)
            {
                AbpLogHelper.Error(ex);
            }
        }
    }
}
