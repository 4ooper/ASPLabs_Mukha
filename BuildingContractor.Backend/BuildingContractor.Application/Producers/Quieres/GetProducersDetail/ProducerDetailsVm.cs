using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersDetail
{
    public class ProducerDetailsVm : IMapWith<Producer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<GetProducerDetailsMaterialDto> Materials { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Producer, ProducerDetailsVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(act => act.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(act => act.Name))
                .ForMember(vm => vm.Materials, opt => opt.MapFrom(act => act.Materials));
        }
    }
}
