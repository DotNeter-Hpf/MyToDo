using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Shared.Dtos
{
    /// <summary>
    /// 备忘录实体
    /// </summary>
    public class MemoDto : BaseDto
    {
        //OnPropertyChanged();
        //这个东西不能少啊，要不然修改完数据页面不会更新


        private string title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }


        private string content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }


        private int status;
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }
    }
}
