using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Quieres.GetProducerSearch
{
    public class ProducerSearchLookupDto : IMapWith<Producer>
    {
        public int id { get; set; }
        public string name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Producer, ProducerSearchLookupDto>()
                .ForMember(producerDto => producerDto.name, opt => opt.MapFrom(producer => producer.name));
        }
    }
}
