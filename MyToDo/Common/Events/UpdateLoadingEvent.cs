using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Common.Events
{
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
