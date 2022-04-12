using MyToDo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Shared.Dtos
{
    /// <summary>
    /// 待办事项实体
    /// </summary>
    public class ToDoDto : BaseDto
    {
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
