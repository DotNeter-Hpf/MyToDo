using MyToDo.Api.Models;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Services.IServices
{
    public interface IMemoService : IBaseService<Memo,MemoDto>
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<MessageModel<PageModel<MemoDto>>> QueryPage(QueryParameter query);
    }
}
