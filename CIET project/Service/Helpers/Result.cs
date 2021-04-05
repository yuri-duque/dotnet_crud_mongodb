namespace Aplication.Helpers
{
    public class Result
    {
        public string Message { get; }
        public object Data { get; }

        public Result(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public Result(string message)
        {
            Message = message;
        }

        public Result(object data)
        {
            Data = data;
        }
    }
}
