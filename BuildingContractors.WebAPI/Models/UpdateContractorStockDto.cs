using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ContractorStocks.Commands.UpdateContractorStock;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateContractorStockDto : IMapWith<UpdateContractorStockCommand>
    {
        public int id { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public ContractorMaterialDto contractorMaterial { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractorStockDto, UpdateContractorStockCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.count,
                    opt => opt.MapFrom(customerDto => customerDto.count))
                .ForMember(customerCommand => customerCommand.price,
                    opt => opt.MapFrom(customerDto => customerDto.price))
                .ForMember(customerCommand => customerCommand.contractorMaterial,
                    opt => opt.MapFrom(customerDto => customerDto.contractorMaterial));
        }
    }
}
