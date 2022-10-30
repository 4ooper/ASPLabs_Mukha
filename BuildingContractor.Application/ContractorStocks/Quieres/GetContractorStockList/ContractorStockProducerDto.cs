using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockList
{
    public class ContractorStockProducerDto : IMapWith<Producer>
    {
        public int id { get; set; }
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Producer, ContractorStockProducerDto>()
                .ForMember(producerDto => producerDto.id, opt => opt.MapFrom(producer => producer.id))
                .ForMember(producerDto => producerDto.name, opt => opt.MapFrom(producer => producer.name));
        }
    }
}
