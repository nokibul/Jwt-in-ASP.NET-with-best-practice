// using Agency.Utilities.Error;

namespace Agency.CommonUtils;
public class ApiResponse<T>
{
    public T Data { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public ApiError Error { get; set; }

    // Constructor for successful responses
    public ApiResponse(T data, string message)
    {
        Data = data;
        Status = "success";
        Message = message;
    }

    // Constructor for error responses
    public ApiResponse(T data, string status, string message, ApiError error)
    {
        Data = data;
        Status = status;
        Message = message;
        Error = error;
    }
}
