using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Platform.Enums
{
    /// <summary>
    /// 枚举公用返回状态信息
    /// atuhor:chenhm
    /// time:2018-07-12
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>请求成功（所有接口请求成功时默认值）</summary>
        [Description("请求成功")]
        OK = 1,

        /// <summary>请求失败（逻辑处理过程中需返回信息时使用）</summary>
        [Description("请求失败已抛异常")]
        Fail = -1,

        /// <summary>身份验证失败（token失效或未登录）</summary>
        [Description("身份验证失败")]
        ValidateFail = -2,

        /// <summary>数据为空（查询数据库找不到数据时使用）</summary>
        [Description("数据为空")]
        NoRecord = -3,

        /// <summary>提交数据检测未通过（验证输入参数时使用）</summary>
        [Description("提交数据检测未通过")]
        RequestValidateFail = -4,

        /// <summary>服务数据异常（异常捕捉时使用）</summary>
        [Description("服务数据异常")]
        HandleError = -5,

        /// <summary>未授权访问系统（abp自身验证不通过时使用）</summary>
        [Description("未授权访问系统")]
        Deny = -6,

        /// <summary>abp系统自身提交数据验证不通过（仅在系统自动判断提交数据不合法时使用）</summary>
        [Description("提交数据验证不通过")]
        AbpRequestValidateFail = -7,


        /// <summary>IP验证有误（逻辑处理过程中需返回信息时使用）</summary>
        [Description("IP验证不通过")]
        IPFail = -8,

        /// <summary>请求密码不正确（逻辑处理过程中需返回信息时使用）</summary>
        [Description("请求密码不正确")]
        PasswordFail = -9,

        /// <summary>传入参数有误或者为空（逻辑处理过程中需返回信息时使用）</summary>
        [Description("传入参数有误或者为空")]
        ParameterFail = -10,

        /// <summary>不允许操作</summary>
        [Description("不允许操作")]
        NotAllow = -11
    }
}
