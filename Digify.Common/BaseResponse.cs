namespace Digify.Common
{
    public class BaseResponse
    {
        public string version { get; set; }
        public string datetime { set; get; }
        public long timestamp { get; set; }
        public string status { set; get; }
        public dynamic code { set; get; }
        public string message { set; get; }
        public dynamic data { set; get; }
        public dynamic errors { set; get; }
        public int page { get; set; }
        public int page_size { get; set; }
        public int count { get; set; }

        public BaseResponse()
        {
            DateTime now = DateTime.UtcNow;
            version = "1.0";
            datetime = now.ToString("u");
            timestamp = ((DateTimeOffset)now).ToUnixTimeSeconds();
            status = "error";
            code = 400;
            message = "Error";
            data = null;
            errors = null;
            page = 0;
            page_size = 0;
        }
    }
}
