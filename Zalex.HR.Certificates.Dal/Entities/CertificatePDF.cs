using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zalex.HR.Certificates.Dal.Entities
{
    [Table("CertificatePDFs")]
    public class CertificatePDF
    {
        [Key]
        public int Id { get; set; }

        public int CertificateRequestId { get; set; }

        public string Pdf { get; set; }


        [ForeignKey(nameof(CertificateRequestId))]
        public virtual CertificateRequest CertificateRequest { get; set; }
    }
}
