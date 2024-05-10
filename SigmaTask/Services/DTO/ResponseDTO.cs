namespace SigmaTask.Services.DTO
{
    public class ResponseDTO<T>
    {
        public string? Message { get; set; }
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }

        public static ResponseDTO<T> Success(T? data, string messages) => new ResponseDTO<T> { Message = messages, Data = data, IsSuccess = true };
        public static ResponseDTO<T> Success(string messages) => new ResponseDTO<T> { Message = messages, Data = default(T), IsSuccess = true };
        public static ResponseDTO<T> Fail(string messages) => new ResponseDTO<T> { Message = messages, Data = default(T), IsSuccess = false };
    }
    public class EmptyResponse
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }

        public static EmptyResponse Success(string messages) => new EmptyResponse { Message = messages, IsSuccess = true };
        public static EmptyResponse Fail(string messages) => new EmptyResponse { Message = messages, IsSuccess = false };
    }
}
