using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Shared.Dtos
{
    /// <summary>
    /// 首页统计实体类
    /// </summary>
    public class SummaryDto : BaseDto
    {
        private int sum;
        /// <summary>
        /// 待办事项总数量
        /// </summary>
        public int Sum
        {
            get { return sum; }
            set { sum = value; OnPropertyChanged(); }
        }


        private int completedCount;
        /// <summary>
        /// 待办事项完成数量
        /// </summary>
        public int CompletedCount
        {
            get { return completedCount; }
            set { completedCount = value; OnPropertyChanged(); }
        }


        private int memoCount;
        /// <summary>
        /// 备忘录总数量
        /// </summary>
        public int MemoCount
        {
            get { return memoCount; }
            set { memoCount = value; OnPropertyChanged(); }
        }


        private string completedRadio;
        /// <summary>
        /// 统计完成比例
        /// </summary>
        public string CompletedRadio
        {
            get { return completedRadio; }
            set { completedRadio = value; OnPropertyChanged(); }
        }


        private ObservableCollection<ToDoDto> todoList;
        /// <summary>
        /// 待办事项列表(未完成数据)
        /// </summary>
        public ObservableCollection<ToDoDto> TodoList
        {
            get { return todoList; }
            set { todoList = value; OnPropertyChanged(); }
        }


        private ObservableCollection<MemoDto> memoList;
        /// <summary>
        /// 备忘录列表
        /// </summary>
        public ObservableCollection<MemoDto> MemoList
        {
            get { return memoList; }
            set { memoList = value; OnPropertyChanged(); }
        }
    }
}
