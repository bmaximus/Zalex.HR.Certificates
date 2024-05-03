namespace Zalex.HR.Certificates.Dal.Services.Repositories
{
    public class CertificatePdfRepository(CertificatesContext certificateContext) : ICertificatePdfRepository
    {
        private CertificatesContext Context = certificateContext;

        public async Task AddNewPdf(int certificateRequestId, string pdf)
        {
            try
            {
                await Context.CertificatePDFs.AddAsync(new Entities.CertificatePDF()
                {
                    Pdf = pdf,
                    CertificateRequestId = certificateRequestId,
                });
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
