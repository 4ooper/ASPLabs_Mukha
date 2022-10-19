using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersDetail
{
    public class ProducerDetailsVm : IMapWith<Producer>
    {
        public int id { get; set; }
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Producer, ProducerDetailsVm>()
                .ForMember(vm => vm.id, opt => opt.MapFrom(act => act.id))
                .ForMember(vm => vm.name, opt => opt.MapFrom(act => act.name));
        }
    }
}
