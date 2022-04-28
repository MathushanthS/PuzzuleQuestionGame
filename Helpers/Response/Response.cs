namespace PuzzuleQuestion.Helpers.Response
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, T? data = default) =>
            new(false, message, data);
        public static Response<T> Ok<T>(T? data, string message) =>
            new(true, message, data);
        public static Response<T> Ok<T>(T? data, string message, string txt) =>
           new(true, message, data, txt);

        
    }
    public class Response<T>
    {
        public Response(bool success, string message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public Response(bool success, string message, T? data, string txt)
        {
            Success = success;
            Message = message;
            Data = data;
            Txt = txt;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public string Txt { get; set; }
    }
}
