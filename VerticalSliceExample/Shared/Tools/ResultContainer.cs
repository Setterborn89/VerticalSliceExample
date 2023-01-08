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
                    HttpStatusCode.Unauthorized => "Sorry, you are not allowed to access the requested serivce",
                    HttpStatusCode.Forbidden => "Sorry, you are not allowed to access the requested serivce",
                    HttpStatusCode.NotFound => "Not found",
                    HttpStatusCode.Conflict => "The content already exists",
                    HttpStatusCode.InternalServerError => "Internal error, please contact the site administrator",
                    _ => "Error",
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

