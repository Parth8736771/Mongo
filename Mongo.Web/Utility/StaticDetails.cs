namespace Mongo.Web.Utility
{
    public static class StaticDetails
    {
        public static string CouponBaseUrl { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
