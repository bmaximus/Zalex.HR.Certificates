namespace Zalex.HR.Certificates.Api.Models.Responses
{
    public class DataResponse<T> : BaseResponse
    {
        public DataResponse(T data) : base()
        {
            Data = data;
        }

        public DataResponse(T data, bool isSuccess, int? errorCode, string? errorMessage) : base(isSuccess, errorCode, errorMessage)
        {
            Data = data;
        }
    }
}
