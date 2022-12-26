using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Materials.Quieres.GetMaterialDetails
{
    public class MaterialDetailsVm : IMapWith<Material>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Material, MaterialDetailsVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(act => act.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(act => act.Name))
                .ForMember(vm => vm.CreationDate, opt => opt.MapFrom(act => act.CreationDate))
                .ForMember(vm => vm.Valid, opt => opt.MapFrom(act => act.Valid));
        }
    }
}
