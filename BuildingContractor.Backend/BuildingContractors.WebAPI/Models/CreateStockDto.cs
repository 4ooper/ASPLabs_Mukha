using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Stocks.Commands.CreateStock;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateStockDto : IMapWith<CreateStockCommand>
    {
        public int Count { get; set; }
        public MaterialDto Material { get; set; }
        public ContractorDto Contractor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateStockDto, CreateStockCommand>()
                .ForMember(recordCommand => recordCommand.Count,
                    opt => opt.MapFrom(recordDto => recordDto.Count))
                .ForMember(recordCommand => recordCommand.MaterialId,
                    opt => opt.MapFrom(recordDto => recordDto.Material.Id))
                .ForMember(recordCommand => recordCommand.ContractorId,
                    opt => opt.MapFrom(recordDto => recordDto.Contractor.Id));
        }
    }
}
