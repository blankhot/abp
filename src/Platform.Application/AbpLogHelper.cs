using Abp.Logging;
using Platform.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform
{
    public class AbpLogHelper
    {
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="e"></param>
        /// <param name="result"></param>
        public static void Error(Exception e, string result = "")
        {
            if (e == null) return;
            var context = HttpContext.Current;
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("【接口名】{0}", context == null ? string.Empty : $"{context.Request.Method}：{context.Request.Scheme}://{context.Request.Host.ToString()}{context.Request.Path.ToString()}");
            builder.AppendFormat("\r\n\r\n【参数】{0}", context == null ? string.Empty : HttpContext.GetQueryJsonStr(context));
            builder.AppendFormat("\r\n\r\n【返回值】{0}", string.IsNullOrEmpty(result) ? string.Empty : result);
            builder.AppendFormat("\r\n\r\n【IP地址】{0}", context == null ? string.Empty : context.Connection.RemoteIpAddress.ToString());
            builder.AppendFormat("\r\n\r\n【错误信息】{0} ", e.Message);
            builder.AppendFormat("\r\n\r\n【错误对象】{0}", e.Source);
            builder.AppendFormat("\r\n\r\n【堆栈跟踪】{0}", e.StackTrace);
            builder.AppendFormat("\r\n\r\n【异常方法】{0}", e.TargetSite);
            LogHelper.Logger.Error(builder.ToString());
        }
    }
}
