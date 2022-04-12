using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services.IServices
{
    public interface ILoginService
    {
        Task<MessageModel<UserDto>> LoginAsync(UserDto userdto);
        Task<MessageModel> RegisterAsync(UserDto userdto);
    }
}
