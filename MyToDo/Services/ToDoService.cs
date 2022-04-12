using MyToDo.Services.IServices;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services
{
    public class ToDoService : BaseService<ToDoDto>, IToDoService
    {
        private readonly HttpRestClient client;

        //ToDo 控制器名称
        public ToDoService(HttpRestClient _httpRestClient) : base(_httpRestClient, "ToDo")
        {
            client = _httpRestClient;
        }

        public async Task<MessageModel<PageModel<ToDoDto>>> QueryPageAsync(ToDoParameter query)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.GET,
                Route = $"api/ToDo/QueryPage?pageIndex={query.PageIndex}" +
                $"&pageSize={query.PageSize}" +
                $"&search={query.Search}" +
                $"&Status={query.Status}"
            };
            return await client.ExcuteAsync<PageModel<ToDoDto>>(request);
        }

        /// <summary>
        /// 首页统计
        /// </summary>
        /// <returns></returns>
        public async Task<MessageModel<SummaryDto>> SummaryAsync()
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.GET,
                Route = $"api/ToDo/Summary"
            };
            return await client.ExcuteAsync<SummaryDto>(request);
        }
    }
}
