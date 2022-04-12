using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Api.Models
{
    public class User : BaseModel
    {
        public string Account { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

    }
}
