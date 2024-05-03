using Zalex.HR.Certificates.Dal.Criteria;
using Zalex.HR.Certificates.Dal.Dto;
using Zalex.HR.Certificates.Dal.Entities;

namespace Zalex.HR.Certificates.Dal.Services.Repositories
{
    public interface ICertificateRequestRepository
    {
        Task AddNewRequest(CertificateRequest cRequest);
        Task<CertificateRequest> GetCertificateById(int certificateRequestId);
        Task<UserCertificateRequestsPaginated> GetUserCertificateRequests(CertificateRequestCriteria criteria);
        Task<bool> UpdatePurposeOfCertificateRequest(int certificateRequestId, string purpose);
    }
}
