using static Mongo.Web.Utility.StaticDetails;

namespace Mongo.Web.Models.Dtos
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
