using System.Net;

namespace VerticalSliceExample.Shared.Tools;

public class ResultContainer<T>
{
    public T? Value { get; set; }
    public string? Message { get; set; } = string.Empty;
    public bool Success { get; set; }

    public ResultContainer(T? data, HttpResponseMessage? response)
    {
        if (response != null)
        {
            if (response.IsSuccessStatusCode)
            {
                Success = true;
                Value = data;
            }
            else
            {
                Success = false;
                Message = response.StatusCode switch
                {
                    HttpStatusCode.BadRequest => "Bad request",
                    HttpStatusCode.Unauthorized => "Unauthorized",
                    HttpStatusCode.Forbidden => "Forbidden",
                    HttpStatusCode.NotFound => "Not found",
                    HttpStatusCode.Conflict => "Conflict",
                    HttpStatusCode.InternalServerError => "Internal error",
                    _ => "Unspecified Error",
                };
            }
        }
        else
        {
            Success = false;
            Message = "null";
        }
    }
}

