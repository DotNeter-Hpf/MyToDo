using AutoMapper;
using MyToDo.Api.Models;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyToDo.Api.Services.IServices
{
    public interface IToDoService : IBaseService<ToDo, ToDoDto>
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<MessageModel<PageModel<ToDoDto>>> QueryPageAsync(ToDoParameter query);

        Task<MessageModel> SummaryAsync();
    }
}
