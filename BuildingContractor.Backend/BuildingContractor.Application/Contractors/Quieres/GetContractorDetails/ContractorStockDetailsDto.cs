using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorDetails
{
    public class ContractorStockDetailsDto : IMapWith<Stock>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public ContractorStockMaterialDetailsDto Material { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Stock, ContractorStockDetailsDto>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Count,
                    opt => opt.MapFrom(recordDto => recordDto.Count))
                .ForMember(recordCommand => recordCommand.Material,
                    opt => opt.MapFrom(recordDto => recordDto.Material));
        }
    }
}
