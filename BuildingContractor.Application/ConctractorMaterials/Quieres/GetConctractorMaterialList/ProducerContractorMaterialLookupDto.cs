using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList
{
    public class ProducerContractorMaterialLookupDto : IMapWith<Producer>
    {
        public int id { get; set; }
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Producer, ProducerContractorMaterialLookupDto>()
                .ForMember(producerDto => producerDto.id, opt => opt.MapFrom(producer => producer.id))
                .ForMember(producerDto => producerDto.name, opt => opt.MapFrom(producer => producer.name));
        }
    }
}
