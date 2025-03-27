namespace Digify.Common
{
    public class ResponseConstant
    {
        public static BaseResponse OK => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "success",
            code = 200,
            message = "OK",
            data = null,
            errors = null
        };

        public static BaseResponse NO_RESULT => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "success",
            code = 200,
            message = "No result",
            data = new List<string>(),
            errors = null
        };

        public static BaseResponse ERROR => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "error",
            code = 400,
            message = "Error",
            data = null,
            errors = null
        };

        public static BaseResponse NOT_FOUND => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "error",
            code = 404,
            message = "Not found",
            data = null,
            errors = null
        };

        public static BaseResponse NOT_AUTHORIZED => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "error",
            code = 401,
            message = "Not authorized",
            data = null,
            errors = null
        };

        public static BaseResponse DUPLICATE_ENTRY => new BaseResponse()
        {
            version = "1.0",
            datetime = DateTime.UtcNow.ToString("u"),
            timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
            status = "error",
            code = 400,
            message = "Duplicate Entry!",
            data = null,
            errors = null
        };
    }
}
