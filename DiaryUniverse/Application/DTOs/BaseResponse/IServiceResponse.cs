namespace DiaryUniverse.Application.DTOs.BaseResponse;

public interface IServiceResponse<out T> 
{
    bool IsSuccess { get; }
    T? Data { get; }
    string ErrorMessage { get; }
    List<string> Errors { get; }
    int StatusCode { get; }
}
