using Mongo.Web.Models.Dtos;
using Mongo.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mongo.Web.Utility.StaticDetails;

namespace Mongo.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("MongoAPI");
                HttpRequestMessage httpRequest = new();
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.RequestUri = new Uri(requestDto.URL);
                if (requestDto.Data != null)
                {
                    httpRequest.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? responceMessage = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        httpRequest.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        httpRequest.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        httpRequest.Method = HttpMethod.Delete;
                        break;
                    default:
                        httpRequest.Method = HttpMethod.Get;
                        break;
                }

                responceMessage = await client.SendAsync(httpRequest);

                switch (responceMessage.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Forbidden" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var httpContent = await responceMessage.Content.ReadAsStringAsync();
                        var responseDto = JsonConvert.DeserializeObject<ResponseDto>(httpContent);
                        return responseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                };
                return dto;
            }
        }
    }
}

