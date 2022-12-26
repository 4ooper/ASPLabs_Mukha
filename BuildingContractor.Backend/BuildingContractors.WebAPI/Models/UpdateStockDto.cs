using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Stocks.Commands.UpdateStock;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateStockDto : IMapWith<UpdateStockCommand>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public MaterialDto Material { get; set; }
        public ContractorDto Contractor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateStockDto, UpdateStockCommand>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Count,
                    opt => opt.MapFrom(recordDto => recordDto.Count))
                .ForMember(recordCommand => recordCommand.MaterialId,
                    opt => opt.MapFrom(recordDto => recordDto.Material.Id))
                .ForMember(recordCommand => recordCommand.ContractorId,
                    opt => opt.MapFrom(recordDto => recordDto.Contractor.Id));
        }
    }
}
