using Abp.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Platform.WebApi
{
    /// <summary>
    /// JSON时间格式化
    /// </summary>
    public class DateFormatContractResolver : AbpContractResolver
    {
        /// <summary>
        /// 重写修改属性
        /// </summary>
        /// <param name="member"></param>
        /// <param name="property"></param>
        protected override void ModifyProperty(MemberInfo member, JsonProperty property)
        {
            //NamingStrategy = new CamelCaseNamingStrategy();
            NamingStrategy = new DefaultNamingStrategy();

            //不是时间类型直接返回
            if (property.PropertyType != typeof(DateTime) && property.PropertyType != typeof(DateTime?))
                return;
            //设置时间格式
            property.Converter = new AbpDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
        }
    }
}
