using Platform.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.DtoTool
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseTokenResultModel<T>: ResponseResultModel<T>
    {
        /// <summary>
        /// token
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// 设置状态值、Message和时间
        /// </summary>
        public ResponseTokenResultModel<T> SetTokenData(ResponseStatus responseStatus, string error = "")
        {
            ResultStatus = responseStatus;
            SetData(error);
            return this;
        }
    }
}
