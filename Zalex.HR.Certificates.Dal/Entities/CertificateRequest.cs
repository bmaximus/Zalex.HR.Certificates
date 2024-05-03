using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zalex.HR.Certificates.Dal.Enums;

namespace Zalex.HR.Certificates.Dal.Entities
{
    [Table("CertificateRequests")]
    public class CertificateRequest
    {
        public CertificateRequest()
        {
            Certificates = new HashSet<CertificatePDF>();
        }

        [Key]
        public int Id { get; set; }
        public required string AddressTo { get; set; }

        [MaxLength(50)]
        public required string Purpose { get; set; }
        public DateTime IssuedOn { get; set; }
        public required string EmployeeId { get; set; }
        public CertificateRequestStatus Status { get; set; }

        public virtual IEnumerable<CertificatePDF> Certificates { get; set; }
    }
}
