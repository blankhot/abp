using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Common.DtoTool
{
    /// <summary>
    /// 公共分页输入
    /// author:chenhm
    /// time:2018-07-12
    /// </summary>
    public class PageBaseInput
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int Limit { get; set; } = 30;

        /// <summary>
        /// 总数据量
        /// </summary>
        public int Total { get; set; } = 0;
    }
}
