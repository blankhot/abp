using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Common.DtoTool
{
    /// <summary>
    /// 公共分页信息
    /// author:chenhm
    /// time:2018-07-12
    /// </summary>
    public class ApiBreakPage
    {

        /// <summary>
        /// 默认PageSize=10
        /// </summary>
        public ApiBreakPage()
        {
            this.mPageIndex = 1;
            this.mPageSize = 10;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        public ApiBreakPage(int pageSize)
        {
            this.mPageSize = pageSize;
        }

        private int mPageIndex;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            set { mPageIndex = value; }
            get
            {
                return mPageIndex < 1 ? 1 : mPageIndex;
            }
        }

        private int mPageSize;
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize
        {
            set { mPageSize = value; }
            get
            {
                return mPageSize < 1 ? 10 : mPageSize;
            }
        }

        private int mTotalItems;
        /// <summary>
        /// 符合条件总记录条数
        /// </summary>
        public int TotalItems
        {
            get { return mTotalItems; }
            set
            {
                mTotalItems = value;
            }
        }

        private string mFilter;
        /// <summary>
        /// 筛选条件
        /// </summary>
        public string Filter
        {
            get { return mFilter; }
            set { mFilter = value; }
        }

        /// <summary>
        /// 符合条件总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                return (int)(mPageSize == 0 ? 0 : Math.Ceiling(TotalItems / (double)mPageSize));
            }
        }

        private bool mIsAsc;
        /// <summary>
        /// 是否升序
        /// </summary>
        public bool IsAsc
        {
            get
            {
                return mIsAsc;
            }
            set
            {
                mIsAsc = value;
            }
        }

        private string mOrderExpression;
        /// <summary>
        /// 排序表达式
        /// </summary>
        public string OrderExpression
        {
            get
            {
                return mOrderExpression;
            }
            set
            {
                mOrderExpression = value;
            }
        }
    }
}
