using DiaryUniverse.Application.DTOs.BaseResponse;
using Microsoft.AspNetCore.Mvc;

namespace DiaryUniverse.Application;

public static class ServiceResponseExtensions
{
    public static IActionResult ToActionResult<T>(this IServiceResponse<T> response)
    {
        if (response.IsSuccess)
        {
            if (response.Data is null)
                return new StatusCodeResult(response.StatusCode);

            return new ObjectResult(response.Data)
            {
                StatusCode = response.StatusCode
            };
        }

        var errorPayload = new
        {
            error = response.ErrorMessage,
            errors = response.Errors
        };

        return new ObjectResult(errorPayload)
        {
            StatusCode = response.StatusCode
        };
    }
}