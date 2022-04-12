using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services.IServices
{
    public interface IBaseService<TDto> where TDto : class
    {
        Task<MessageModel<TDto>> AddAsync(TDto tDto);

        Task<MessageModel<TDto>> UpdateAsync(TDto tDto);

        Task<MessageModel> DeleteAsync(int id);

        Task<MessageModel<TDto>> GetSinglesync(int id);

        Task<MessageModel<PageModel<TDto>>> QueryPage(QueryParameter query);

    }
}
