using MyToDo.Services.IServices;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services
{
    public class MemoService : BaseService<MemoDto>, IMemoService
    {
        //Memo 控制器名称
        public MemoService(HttpRestClient _httpRestClient) : base(_httpRestClient, "Memo")
        {

        }
    }
}
