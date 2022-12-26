using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorDetails
{
    public class ContractorDetailsVm : IMapWith<Contractor>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contractor, ContractorDetailsVm>()
                .ForMember(recordVm => recordVm.Name, opt => opt.MapFrom(record => record.Name))
                .ForMember(recordVm => recordVm.Id, opt => opt.MapFrom(record => record.Id));
        }
    }
}
