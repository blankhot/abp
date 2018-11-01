using Platform.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Common.DtoTool
{
    /// <summary>
    /// 输出时调用基类
    /// author:chenhm
    /// time:2018-07-12
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseResultModel<T> : BaseResponseDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public ResponseResultModel()
        {
            Data = default(T);
        }
        /// <summary>
        /// 返回实体
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 是否为默认值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDefault(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
        /// <summary>
        /// 设置Message和时间
        /// </summary>
        public ResponseResultModel<T> SetData(string error = "")
        {
            Message = string.IsNullOrEmpty(error) ? EnumHelper.GetEnumDescription(ResultStatus) : error;
            Time = DateTime.Now;
            return this;
        }
        /// <summary>
        /// 设置状态值、Message和时间
        /// </summary>
        public ResponseResultModel<T> SetData(ResponseStatus responseStatus, string error = "")
        {
            ResultStatus = responseStatus;
            SetData(error);
            return this;
        }
        /// <summary>
        /// 设置状态值、Data、Message和时间
        /// </summary>
        public ResponseResultModel<T> SetData(ResponseStatus responseStatus, T data, string error = "")
        {
            ResultStatus = responseStatus;
            Data = data;
            SetData(error);
            return this;
        }
        /// <summary>
        /// 返回错误
        /// </summary>
        /// <param name="data">错误时返回对象</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public ResponseResultModel<T> ResponseErrorResult(T data, string error = "")
        {
            return SetData(ResponseStatus.HandleError, data, error);            
        }
        /// <summary>
        /// 返回空值
        /// </summary>
        /// <param name="error">指定返回信息</param>
        /// <returns></returns>
        public ResponseResultModel<T> ResponseEmptyResult(string error = "")
        {
            return SetData(ResponseStatus.NoRecord, error);
        }
    }
}
