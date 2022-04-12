using MyToDo.Shared.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Services
{
    public class HttpRestClient
    {
        private readonly string apiUrl;
        protected readonly RestClient client;

        public HttpRestClient(string _apiUrl)
        {
            this.apiUrl = _apiUrl;
            client = new RestClient();
        }

        public async Task<MessageModel> ExcuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Parameter != null)
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            client.BaseUrl = new Uri(apiUrl + baseRequest.Route);

            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<MessageModel>(response.Content);
            else
                return new MessageModel()
                {
                    status = ResultStatus.Fail,
                    msg = response.ErrorMessage
                };
        }


        public async Task<MessageModel<T>> ExcuteAsync<T>(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Parameter != null)
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            client.BaseUrl = new Uri(apiUrl + baseRequest.Route);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<MessageModel<T>>(response.Content);
            else
                return new MessageModel<T>()
                {
                    status = ResultStatus.Fail,
                    msg = response.ErrorMessage
                };

           
        }
    }
}
