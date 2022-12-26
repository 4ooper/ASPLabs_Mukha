using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingDetails
{
    public class GetBuildingDetailsVm : IMapWith<Building>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetBuildingDetailsCustomerDto Customer { get; set; }
        public GetBuildingDetailsContractorDto Contractor { get; set; }
        public DateTime ConclusionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ComissioningDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Building, GetBuildingDetailsVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(act => act.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(act => act.Name))
                .ForMember(vm => vm.Contractor, opt => opt.MapFrom(act => act.Contractor))
                .ForMember(vm => vm.ConclusionDate, opt => opt.MapFrom(act => act.ConclusionDate))
                .ForMember(vm => vm.DeliveryDate, opt => opt.MapFrom(act => act.DeliveryDate))
                .ForMember(vm => vm.ComissioningDate, opt => opt.MapFrom(act => act.ComissioningDate));
        }
    }
}
