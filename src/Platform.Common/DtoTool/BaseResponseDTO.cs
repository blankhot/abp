using Platform.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Common.DtoTool
{
    /// <summary>
    /// 返回基本信息类
    /// author:chenhm
    /// time:2018-08-12
    /// </summary>
    public class BaseResponseDTO
    {
        public BaseResponseDTO()
        {
            Message = "正常返回！";
        }

        /// <summary>
        /// 标示代码 1:正确
        /// </summary>
        public ResponseStatus ResultStatus { get; set; }

        /// <summary>
        /// 返回消息描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
