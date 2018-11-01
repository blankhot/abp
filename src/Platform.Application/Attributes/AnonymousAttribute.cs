using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.Attributes
{
    /// <summary>
    /// 匿名访问标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class AnonymousAttribute:Attribute
    {
    }
}
