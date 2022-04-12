using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services.IServices
{
    public interface IToDoService : IBaseService<ToDoDto>
    {
        Task<MessageModel<PageModel<ToDoDto>>> QueryPageAsync(ToDoParameter query);

        Task<MessageModel<SummaryDto>> SummaryAsync();
    }
}
