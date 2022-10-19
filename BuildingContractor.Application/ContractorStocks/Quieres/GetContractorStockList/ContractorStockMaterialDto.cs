using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockList
{
    public class ContractorStockMaterialDto : IMapWith<ConctractorMaterial>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }
        public ContractorStockProducerDto? producer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConctractorMaterial, ContractorStockMaterialDto>()
                .ForMember(producerDto => producerDto.id, opt => opt.MapFrom(producer => producer.id))
                .ForMember(producerDto => producerDto.name, opt => opt.MapFrom(producer => producer.name))
                .ForMember(producerDto => producerDto.createdDate, opt => opt.MapFrom(producer => producer.createdDate))
                .ForMember(producerDto => producerDto.validaty, opt => opt.MapFrom(producer => producer.validaty))
                .ForMember(producerDto => producerDto.producer, opt => opt.MapFrom(producer => producer.producer));
        }
    }
}
