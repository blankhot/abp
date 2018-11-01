﻿using Platform.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.Common.DtoTool
{
    public interface IResult
    {
        /// <summary>
        /// 结果状态码
        /// </summary>
        ResponseStatus Code { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <example>操作成功</example>
        string Message { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// 返回时间
        /// </summary>
        DateTime Time { get; set; }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public interface IResult<TData> : IResult
    {
        /// <summary>
        /// 结果状态码
        /// </summary>
        TData Data { get; set; }
    }
}
