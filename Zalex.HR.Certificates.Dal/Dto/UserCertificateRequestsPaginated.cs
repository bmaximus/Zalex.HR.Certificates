using Zalex.HR.Certificates.Dal.Entities;

namespace Zalex.HR.Certificates.Dal.Dto
{
    public class UserCertificateRequestsPaginated
    {
        public UserCertificateRequestsPaginated()
        {
            CertificateRequests = new List<CertificateRequest>();
        }

        public UserCertificateRequestsPaginated(List<CertificateRequest> certificateRequests, int total)
        {
            CertificateRequests = certificateRequests;
            Total = total;
        }

        public List<CertificateRequest> CertificateRequests { get; set; }
        public int Total { get; set; }
    }
}
