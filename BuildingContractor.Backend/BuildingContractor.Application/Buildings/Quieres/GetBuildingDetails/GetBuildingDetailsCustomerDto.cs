using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingDetails
{
    public class GetBuildingDetailsCustomerDto : IMapWith<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, GetBuildingDetailsCustomerDto>()
                .ForMember(recordVm => recordVm.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordVm => recordVm.Name, opt => opt.MapFrom(record => record.Name));
        }
    }
}
