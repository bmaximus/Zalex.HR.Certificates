namespace Zalex.HR.Certificates.Dal.Services.Repositories
{
    public interface ICertificatePdfRepository
    {
        Task AddNewPdf(int certificateRequestId, string pdf);
    }
}
