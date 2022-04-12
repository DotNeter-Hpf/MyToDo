using Microsoft.AspNetCore.Mvc;
using MyToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Controllers
{
    public class BaseApiController : Controller
    {
        // [NonAction]：指示控制器方法不是操作方法

        [NonAction]
        public MessageModel<T> Success<T>(T data, string msg = "成功")
        {
            return new MessageModel<T>()
            {
                msg = msg,
                response = data,
            };
        }
        

        [NonAction]
        public MessageModel Success(string msg = "成功")
        {
            return new MessageModel()
            {
                msg = msg,
                response = null,
            };
        }


        [NonAction]
        public MessageModel<string> Failed(string msg = "失败", int status = 500)
        {
            return new MessageModel<string>()
            {
                status = ResultStatus.Success,
                msg = msg,
                response = null,
            };
        }


        [NonAction]
        public MessageModel<T> Failed<T>(string msg = "失败", int status = 500)
        {
            return new MessageModel<T>()
            {
                status = ResultStatus.Fail,
                msg = msg,
                response = default,
            };
        }


        [NonAction]
        public MessageModel<PageModel<T>> SuccessPage<T>(int page, int dataCount, int pageSize, List<T> data, int pageCount, string msg = "获取成功")
        {
            return new MessageModel<PageModel<T>>()
            {
                msg = msg,
                response = new PageModel<T>(page, dataCount, pageSize, data)

            };
        }


        [NonAction]
        public MessageModel<PageModel<T>> SuccessPage<T>(PageModel<T> pageModel, string msg = "获取成功")
        {
            return new MessageModel<PageModel<T>>()
            {
                msg = msg,
                response = pageModel
            };
        }
    }
}
