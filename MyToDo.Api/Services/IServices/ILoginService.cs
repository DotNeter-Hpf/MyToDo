using MyToDo.Api.Models;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Services.IServices
{
    public interface ILoginService : IBaseService<User, UserDto>
    {
        Task<MessageModel> LoginAsync(UserDto user);


        Task<MessageModel> RegisterAsync(UserDto user);

    }
}
