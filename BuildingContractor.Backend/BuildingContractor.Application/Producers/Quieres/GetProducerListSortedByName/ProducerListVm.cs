using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Quieres.GetProducerListSortedByName
{
    public class ProducerListVm : IMapWith<Producer>
    {
        //public int id { get; set; }
        //public string name { get; set; }
        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Producer, ProducerLookupDto>()
        //        .ForMember(producerDto => producerDto.name, opt => opt.MapFrom(producer => producer.name));
        //}
    }
}
