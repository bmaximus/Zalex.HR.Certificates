using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zalex.HR.Certificates.Api.Authorization;
using Zalex.HR.Certificates.Api.Extensions;
using Zalex.HR.Certificates.Api.Models.Requests;
using Zalex.HR.Certificates.Api.Models.Responses;
using Zalex.HR.Certificates.Dal.Dto;
using Zalex.HR.Certificates.Dal.Services.Repositories;

namespace Zalex.HR.Certificates.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuthorization]
    public class CertificationController : BaseController
    {
        private readonly ICertificateRequestRepository _certificateRequestRepository;
        private readonly ICertificatePdfRepository _certificatePdfRepository;

        public CertificationController(ICertificateRequestRepository certificateRequestRepository,
                                       ICertificatePdfRepository certificatePdfRepository,
                                       IMapper mapper) : base(mapper)
        {
            _certificateRequestRepository = certificateRequestRepository;
            _certificatePdfRepository = certificatePdfRepository;
        }

        [HttpPost("Create")]
        public async Task<BaseResponse> CertificationRequest([FromBody] CertificateRequest request)
        {
            try
            {
                var criteriaRequest = AutoMapper.Map<Dal.Entities.CertificateRequest>(request);
                await _certificateRequestRepository.AddNewRequest(criteriaRequest);
            }
            catch (Exception ex)
            {
                return ReurnCatchError(ex);
            }
            return ReturnSuccess("Created Successfully");
        }

        [HttpPost("GetAll")]
        public async Task<BaseResponse> GetUserCertificateRequests([FromBody] GetUserCertificateRequestCriteriaRequest criteria)
        {
            try
            {
                var certificateCriteria = AutoMapper.Map<Dal.Criteria.CertificateRequestCriteria>(criteria);
                var requestsPaginated = await _certificateRequestRepository.GetUserCertificateRequests(certificateCriteria);

                return new DataResponse<UserCertificateRequestsPaginated>(requestsPaginated);
            }
            catch (Exception ex)
            {
                return ReurnCatchError(ex);
            }
        }

        [HttpGet("GetCertificateDetails/{certificateRequestId}")]
        public async Task<BaseResponse> GetCertificateDetails(string certificateRequestId)
        {
            if (string.IsNullOrEmpty(certificateRequestId) || !int.TryParse(certificateRequestId, out var requestId))
                return Return500ErrorWithMessage("Invalid Argument");

            try
            {
                Dal.Entities.CertificateRequest certificateRequest = await _certificateRequestRepository.GetCertificateById(requestId);
                if (certificateRequest == null)
                    return new DataResponse<Dal.Entities.CertificateRequest>(null);


                return new DataResponse<Dal.Entities.CertificateRequest>(certificateRequest);

            }
            catch (Exception ex)
            {
                return ReurnCatchError(ex);
            }
        }

        [HttpGet("DownloadCertificate/{certificateRequestId}")]
        public async Task<BaseResponse> DownloadCertificate(string certificateRequestId)
        {
            if (string.IsNullOrEmpty(certificateRequestId) || !int.TryParse(certificateRequestId, out var requestId))
                return Return500ErrorWithMessage("Invalid Argument");

            try
            {
                var certificateRequest = await _certificateRequestRepository.GetCertificateById(requestId);
                if (certificateRequest == null)
                    return Return500ErrorWithMessage("Could not find CertificateRequest");

                var binaryPdf = PdfGeneratorExtension.GenerateSimplePdf(certificateRequest);
                if (binaryPdf == null)
                    return Return500ErrorWithMessage("Failed to create PDF");

                var stringPdf = Convert.ToBase64String(binaryPdf);
                await _certificatePdfRepository.AddNewPdf(certificateRequest.Id, stringPdf);

                return new DataResponse<string>(stringPdf);
            }
            catch (Exception ex)
            {
                return ReurnCatchError(ex);
            }
        }

        [HttpPost("UpdatePurpose")]
        public async Task<BaseResponse> UpdateCertificateRequest(UpdateCertificatePurposeRequest updateCertificateRequest)
        {
            try
            {
                var updated = await _certificateRequestRepository.UpdatePurposeOfCertificateRequest(updateCertificateRequest.CertificateRequestId, updateCertificateRequest.Purpose); ;
                return updated ? ReturnSuccess("Updated Successfully") : Return500ErrorWithMessage("Failed to Update");
            }
            catch (Exception ex)
            {
                return ReurnCatchError(ex);
            }
        }
    }
}
