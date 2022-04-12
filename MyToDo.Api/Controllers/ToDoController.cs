using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Models;
using MyToDo.Api.Services.IServices;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 待办事项控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController : BaseApiController
    {
        private readonly IToDoService iToDoService;

        public ToDoController(IToDoService _itoDoService)
        {
            iToDoService = _itoDoService;
        }


        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel> GetAll() => await iToDoService.GetAllAsync();


        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        [HttpGet]
        public async Task<MessageModel> GetSingle(int id) => await iToDoService.GetSingleAsync(id);


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<PageModel<ToDoDto>>> QueryPage([FromQuery] ToDoParameter query)
            => await iToDoService.QueryPageAsync(query);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<ToDo>> Add([FromBody] ToDoDto model) => await iToDoService.AddAsync(model);


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel> Update([FromBody] ToDoDto model) => await iToDoService.UpdateAsync(model);



        /// <summary>
        /// 根据ID删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel> Delete(int id) => await iToDoService.DeleteAsync(id);


        /// <summary>
        /// 首页数据的获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel> Summary() => await iToDoService.SummaryAsync();
    }
}
