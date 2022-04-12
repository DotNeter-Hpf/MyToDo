using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyToDo.Api.Services.IServices;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 账户控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : BaseApiController
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }


        /// <summary>
        /// 注册功能
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel> Register(UserDto userDto) => await loginService.RegisterAsync(userDto);


        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel> Login(UserDto userDto) => await loginService.LoginAsync(userDto);


        /// <summary>
        /// 使用 NETCore.MailKit 实现发送邮件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {

            return Ok();
        }
    }
}
