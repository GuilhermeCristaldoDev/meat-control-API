namespace meat_console_API.Shared
{
    public class Result<T>
    {
        public bool Success { get; }
        public T? Data { get; }
        public string? Error { get; }

        public Result(bool success, T? data, string? error)
        {
            Success = success;
            Data = data;
            Error = error;
        }

        public static Result<T> Ok(T? data) => new(true, data, null);
        public static Result<T> Fail(string message) => new(false, default, message);
    }

    public class Result
    {
        public bool Success { get; }
        public string? Error { get;}

        public Result(bool success, string? error)  
        {
            Success = success;
            Error = error;
        }

        public static Result Ok() => new(true, null);
        public static Result Fail(string message) => new(false, message);
    }
}
