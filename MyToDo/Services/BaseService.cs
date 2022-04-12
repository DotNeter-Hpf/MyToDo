using MyToDo.Services.IServices;
using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services
{
    public class BaseService<TDto> : IBaseService<TDto> where TDto : class
    {
        private readonly HttpRestClient client;
        private readonly string serviceName;

        //_serviceName 控制器名称
        public BaseService(HttpRestClient _httpRestClient, string _serviceName)
        {
            client = _httpRestClient;
            serviceName = _serviceName;
        }
        public async Task<MessageModel<TDto>> AddAsync(TDto entity)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.POST,
                Route = $"api/{serviceName}/Add",
                Parameter = entity
            };
            return await client.ExcuteAsync<TDto>(request);
        }

        public async Task<MessageModel> DeleteAsync(int id)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.DELETE,
                Route = $"api/{serviceName}/Delete?id={id}"
            };
            return await client.ExcuteAsync(request);
        }

        public async Task<MessageModel<PageModel<TDto>>> QueryPage(QueryParameter query)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.GET,
                Route = $"api/{serviceName}/QueryPage?pageIndex={query.PageIndex}&pageSize={query.PageSize}&search={query.Search}"
            };
            return await client.ExcuteAsync<PageModel<TDto>>(request);
        }

        public async Task<MessageModel<TDto>> GetSinglesync(int id)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.GET,
                Route = $"api/{serviceName}/GetSingle?id={id}"
            };
            return await client.ExcuteAsync<TDto>(request);
        }

        public async Task<MessageModel<TDto>> UpdateAsync(TDto entity)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.POST,
                Route = $"api/{serviceName}/Update",
                Parameter = entity
            };
            return await client.ExcuteAsync<TDto>(request);
        }


    }
}
