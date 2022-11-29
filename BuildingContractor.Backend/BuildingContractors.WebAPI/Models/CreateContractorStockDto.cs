using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ContractorStocks.Commands.CreateContractorStock;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateContractorStockDto : IMapWith<CreateContractorStockCommand>
    {
        public int count { get; set; }
        public int price { get; set; }
        public ContractorMaterialDto conctractorMaterial { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractorStockDto, CreateContractorStockCommand>()
                .ForMember(customerCommand => customerCommand.count,
                    opt => opt.MapFrom(customerDto => customerDto.count))
                .ForMember(customerCommand => customerCommand.price,
                    opt => opt.MapFrom(customerDto => customerDto.price))
                .ForMember(customerCommand => customerCommand.conctractorMaterial,
                    opt => opt.MapFrom(customerDto => customerDto.conctractorMaterial));
        }
    }
}
