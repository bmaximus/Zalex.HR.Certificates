using AutoMapper;
using Zalex.HR.Certificates.Api.Models.Requests;

namespace Zalex.HR.Certificates.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CertificateRequest, Dal.Entities.CertificateRequest>()
                .ForMember(d => d.Status, s => s.MapFrom(b => Dal.Enums.CertificateRequestStatus.Requested));

            CreateMap<GetUserCertificateRequestCriteriaRequest, Dal.Criteria.CertificateRequestCriteria>()
                .ForMember(d => d.CertificateRequestId, s => s.MapFrom(b => b.FilterCertificationRequestId))
                .ForMember(d => d.AddressTo, s => s.MapFrom(b => b.FilterAddressTo))
                .ForMember(d => d.Status, s => s.MapFrom(b => b.FilterStatus));
        }
    }
}
