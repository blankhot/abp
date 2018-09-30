using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.WebApi
{
    /// <summary>
    /// Swagger隐藏API特性，继承特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public partial class HiddenApiAttribute : Attribute { }
    /// <summary>
    /// 隐藏特性具体实现
    /// </summary>
    public class HiddenApiFilter : IDocumentFilter
    {
        /// <summary>
        /// 重写Apply
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (ApiDescription apiDescription in context.ApiDescriptionsGroups.Items.SelectMany(e => e.Items))
            {
                if (apiDescription.ControllerAttributes().OfType<HiddenApiAttribute>().Count() == 0
                    && apiDescription.ActionAttributes().OfType<HiddenApiAttribute>().Count() == 0) continue;

                var key = "/" + apiDescription.RelativePath.TrimEnd('/');
                if (!key.Contains("/test/") && swaggerDoc.Paths.ContainsKey(key))
                    swaggerDoc.Paths.Remove(key);
            }
        }
    }
}
