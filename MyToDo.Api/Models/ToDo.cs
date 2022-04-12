using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Api.Models
{
    public class ToDo : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
    }
}
