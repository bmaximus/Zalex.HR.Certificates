using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Zalex.HR.Certificates.Api.Models.Requests
{
    public partial class CertificateRequest
    {
        [JsonRequired]
        [JsonPropertyName("address_to")]
        public required string AddressTo { get; set; }

        [JsonRequired]
        [JsonPropertyName("purpose")]
        [MaxLength(50, ErrorMessage = "Purpose must be maximum 50 characters long.")]
        public required string Purpose { get; set; }

        [JsonRequired]
        [JsonPropertyName("issued_on")]
        [FutureDate(ErrorMessage = "IssuedOn must be a future date.")]
        public DateTime IssuedOn { get; set; }

        [JsonRequired]
        [JsonPropertyName("employee_id")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "EmployeeId should be numeric.")]
        public required string EmployeeId { get; set; }
    }
}