using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Api.Models
{
    /// <summary>
    /// 实体类的基类
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并自增
        public int Id { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }


        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
