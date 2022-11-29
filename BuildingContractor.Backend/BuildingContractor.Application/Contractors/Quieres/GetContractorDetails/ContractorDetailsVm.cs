using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorDetails
{
    public class ContractorDetailsVm : IMapWith<Contractor>
    {
        public int id { get; set; }
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contractor, ContractorDetailsVm>()
                .ForMember(customerVm => customerVm.name, opt => opt.MapFrom(customer => customer.name))
                .ForMember(customerVm => customerVm.id, opt => opt.MapFrom(customer => customer.id));
        }
    }
}
