﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Api.Models
{
    public class Memo : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
