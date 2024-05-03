using Microsoft.EntityFrameworkCore;
using Zalex.HR.Certificates.Dal.Entities;

namespace Zalex.HR.Certificates.Dal
{
    public class CertificatesContext : DbContext
    {
        public CertificatesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CertificateRequest> CertificateRequests { get; set; }
        public DbSet<CertificatePDF> CertificatePDFs { get; set; }
    }
}
