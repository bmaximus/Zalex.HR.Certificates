using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zalex.HR.Certificates.Dal.Enums;

namespace Zalex.HR.Certificates.Api.Models.Requests
{
    public class GetUserCertificateRequestCriteriaRequest
    {
        public GetUserCertificateRequestCriteriaRequest()
        {
            Page = 1;
            PageSize = 10;
            SortByIssuedOn = null;
            SortByStatus = null;
            FilterCertificationRequestId = null;
            FilterAddressTo = null;
        }

        [JsonRequired]
        [JsonPropertyName("employee_id")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "EmployeeId should be numeric.")]
        public string EmployeeId { get; set; }

        [DefaultValue(null)]
        public bool? SortByIssuedOn { get; set; } = null;

        [DefaultValue(null)]
        public bool? SortByStatus { get; set; } = null;

        [DefaultValue(null)]
        public int? FilterCertificationRequestId { get; set; }

        [DefaultValue(null)]
        public string? FilterAddressTo { get; set; }

        [DefaultValue(null)]
        [EnumDataType(typeof(CertificateRequestStatus), ErrorMessage = "Invalid status value.")]
        public CertificateRequestStatus? FilterStatus { get; set; }

        [DefaultValue(1)]
        [Range(1, int.MaxValue, ErrorMessage = "Page should be a positive integer.")]
        public int Page { get; set; }

        [DefaultValue(10)]
        [Range(1, int.MaxValue, ErrorMessage = "PageSize should be a positive integer.")]
        public int PageSize { get; set; }
    }
}
