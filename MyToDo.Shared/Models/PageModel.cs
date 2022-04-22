using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Shared.Models
{
    /// <summary>
    /// 通用分页信息类
    /// </summary>
    public class PageModel<T>
    {
        /// <summary>
        /// 当前页标
        /// </summary>
        public int page { get; set; } = 1;
        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount => (int)Math.Ceiling((decimal)dataCount / PageSize);

        /// <summary>
        /// 数据总数
        /// </summary>
        public int dataCount { get; set; } = 0;
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { set; get; } = 20;
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> data { get; set; }

        public PageModel() { }

        public PageModel(int page, int dataCount, int pageSize, List<T> data)
        {
            this.page = page;
            this.dataCount = dataCount;
            this.PageSize = pageSize;
            this.data = data;
        }

        
    }
}
