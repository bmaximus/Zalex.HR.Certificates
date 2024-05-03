using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Zalex.HR.Certificates.Api.Models.Requests
{
    public class UpdateCertificatePurposeRequest
    {
        [Required]
        public int CertificateRequestId { get; set; }

        [Required]
        [JsonPropertyName("purpose")]
        [MaxLength(50, ErrorMessage = "Purpose must be maximum 50 characters long.")]
        public string Purpose { get; set; }
    }
}
