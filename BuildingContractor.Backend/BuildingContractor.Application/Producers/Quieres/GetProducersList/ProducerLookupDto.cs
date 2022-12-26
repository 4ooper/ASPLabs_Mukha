using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersList
{
    public class ProducerLookupDto : IMapWith<Producer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Producer, ProducerLookupDto>()
                .ForMember(recordDto => recordDto.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordDto => recordDto.Name, opt => opt.MapFrom(record => record.Name));
        }
    }
}
