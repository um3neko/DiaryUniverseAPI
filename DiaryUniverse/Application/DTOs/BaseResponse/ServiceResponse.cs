namespace DiaryUniverse.Application.DTOs.BaseResponse;

public class ServiceResponse<T> : IServiceResponse<T>
{
    public bool IsSuccess { get; private init; }
    public T? Data { get; private init; }
    public string ErrorMessage { get; private init; }
    public List<string> Errors { get; private init; }
    public int StatusCode { get; private init; }

    private ServiceResponse() { }
    
    public static ServiceResponse<T> Success(T data, int statusCode = 200)
    {
        return new ServiceResponse<T>
        {
            IsSuccess = true,
            Data = data,
            StatusCode = statusCode,
            Errors = new List<string>()
        };
    }

    public static ServiceResponse<T> Success(int statusCode = 200)
    {
        return new ServiceResponse<T>
        {
            IsSuccess = true,
            Data = default(T),
            StatusCode = statusCode,
            Errors = new List<string>()
        };
    }
    
    public static ServiceResponse<T> Failure(string errorMessage, int statusCode = 400)
    {
        return new ServiceResponse<T>
        {
            IsSuccess = false,
            ErrorMessage = errorMessage,
            StatusCode = statusCode,
            Errors = new List<string> { errorMessage }
        };
    }
    
    public static ServiceResponse<T> Failure(List<string> errors, int statusCode = 400)
    {
        return new ServiceResponse<T>
        {
            IsSuccess = false,
            Errors = errors,
            StatusCode = statusCode
        };
    }
}
