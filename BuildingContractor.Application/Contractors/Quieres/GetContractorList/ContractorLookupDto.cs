using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorList
{
    public class ContractorLookupDto : IMapWith<Contractor>
    {
        public int id { get; set; }
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contractor, ContractorLookupDto>()
                .ForMember(customerDto => customerDto.id, opt => opt.MapFrom(customer => customer.id))
                .ForMember(customerDto => customerDto.name, opt => opt.MapFrom(customer => customer.name));
        }
    }
}
