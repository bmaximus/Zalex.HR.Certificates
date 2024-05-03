using Microsoft.EntityFrameworkCore;
using Zalex.HR.Certificates.Dal.Criteria;
using Zalex.HR.Certificates.Dal.Dto;
using Zalex.HR.Certificates.Dal.Entities;

namespace Zalex.HR.Certificates.Dal.Services.Repositories
{

    public class CertificateRequestRepository(CertificatesContext certificateContext) : ICertificateRequestRepository
    {
        private CertificatesContext Context = certificateContext;

        private IQueryable<CertificateRequest> BaseSearch(CertificateRequestCriteria criteria)
        {
            var querable = Context.CertificateRequests.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.EmployeeId))
                querable = querable.Where(d => d.EmployeeId == criteria.EmployeeId);

            if (!string.IsNullOrEmpty(criteria.AddressTo))
                querable = querable.Where(d => d.AddressTo.Contains(criteria.AddressTo));

            if (criteria.CertificateRequestId.HasValue)
                querable = querable.Where(d => d.Id == criteria.CertificateRequestId.Value);

            if (criteria.Status.HasValue)
                querable = querable.Where(d => d.Status == criteria.Status.Value);

            if (criteria.SortByIssuedOn.HasValue)
                querable = querable.OrderBy(d => d.IssuedOn);

            if (criteria.SortByStatus.HasValue)
                querable = querable.OrderBy(d => (int)d.Status);

            return querable;
        }

        public async Task AddNewRequest(CertificateRequest cRequest)
        {
            try
            {
                await Context.CertificateRequests.AddAsync(cRequest);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserCertificateRequestsPaginated> GetUserCertificateRequests(CertificateRequestCriteria criteria)
        {
            try
            {
                var query = BaseSearch(criteria);
                var totalItems = query.Count();
                var requests = await query.Skip((criteria.Page - 1) * criteria.PageSize).Take(criteria.PageSize).ToListAsync();

                return new UserCertificateRequestsPaginated(requests, totalItems);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CertificateRequest> GetCertificateById(int certificateRequestId)
        {
            try
            {
                var query = BaseSearch(new CertificateRequestCriteria() { CertificateRequestId = certificateRequestId });
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdatePurposeOfCertificateRequest(int certificateRequestId, string purpose)
        {
            try
            {
                var query = BaseSearch(new CertificateRequestCriteria() { CertificateRequestId = certificateRequestId });
                var certificateRequest = await query.FirstOrDefaultAsync();
                if (certificateRequest == null)
                    return false;


                certificateRequest.Purpose = purpose;
                Context.Update(certificateRequest);
                var rowsAffected = await Context.SaveChangesAsync();
                return rowsAffected == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
