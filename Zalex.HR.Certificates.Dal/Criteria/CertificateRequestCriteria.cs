using Zalex.HR.Certificates.Dal.Enums;

namespace Zalex.HR.Certificates.Dal.Criteria
{
    public class CertificateRequestCriteria
    {
        public string? EmployeeId { get; set; }
        public bool? SortByIssuedOn { get; set; }
        public bool? SortByStatus { get; set; }
        public int? CertificateRequestId { get; set; }
        public string? AddressTo { get; set; }
        public CertificateRequestStatus? Status { get; set; }

        #region Pagination
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
        #endregion
    }
}
