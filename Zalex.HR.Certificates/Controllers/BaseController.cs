using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zalex.HR.Certificates.Api.Extensions;
using Zalex.HR.Certificates.Api.Models.Responses;

namespace Zalex.HR.Certificates.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper AutoMapper;

        public BaseController(IMapper mapper)
        {
            AutoMapper = mapper;
        }

        protected static BaseResponse ReturnSuccess(string successMessage)
        {
            return new DataResponse<string>(successMessage);
        }

        protected static BaseResponse ReurnCatchError(Exception ex) => Return500ErrorWithMessage(ex.GetInnerMessage());

        protected static BaseResponse Return500ErrorWithMessage(string errorMessage) => new BaseResponse(StatusCodes.Status500InternalServerError, errorMessage);
    }
}
