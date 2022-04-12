using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api
{
    public class Config
    {
        /// <summary>
        /// Account have permission to create database
        /// </summary>
        public static readonly string ConnectionString = "server=127.0.0.1;Database=ToDoDB;Uid=root;Pwd=root; AllowLoadLocalInfile=true;";
    }
}
