using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Common.Events
{
    /// <summary>
    /// 事件聚合器
    /// </summary>
    public class UpdateLoadingEvent:PubSubEvent<UpdateModel>
    {

    }

    public class UpdateModel
    {
        /// <summary>
        /// 标识窗口是否是打开状态
        /// </summary>
        public bool IsOpen { get; set; }
    }
}
