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
    public class LoginService : ILoginService
    {
        private readonly HttpRestClient client;
        private readonly string serviceName = "Login";

        public LoginService(HttpRestClient _httpRestClient)
        {
            client = _httpRestClient;
        }


        public async Task<MessageModel<UserDto>> LoginAsync(UserDto userdto)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.POST,
                Route = $"api/Login/Login",
                Parameter = userdto
            };
            return await client.ExcuteAsync<UserDto>(request);
        }

        public async Task<MessageModel> RegisterAsync(UserDto userdto)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.POST,
                Route = $"api/Login/Register",
                Parameter = userdto
            };
            return await client.ExcuteAsync(request);
        }
    }
}
