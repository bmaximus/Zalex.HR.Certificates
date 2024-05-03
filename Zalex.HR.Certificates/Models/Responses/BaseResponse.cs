namespace Zalex.HR.Certificates.Api.Models.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            IsSuccess = true;
            Data = default;
        }

        public BaseResponse(int errorCode, string errorMessage) : this()
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
        public BaseResponse(bool isSuccess, int? errorCode, string? errorMessage) : this()
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public int? ErrorCode { get; set; }
        public virtual object? Data { get; set; }
    }
}
