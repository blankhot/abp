using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Common.DtoTool
{
    /// <summary>
    /// 公共分页信息输出
    /// author:chenhm
    /// time:2018-07-12
    /// </summary>
    public class PageBaseOutput<T>
    {
        public PageBaseOutput()
        {
            Data = new List<T>();
        }

        public List<T> Data { get; set; }
        
        public int Count { get; set; }
    }
}
