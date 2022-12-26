using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Common.Mappings;

namespace BuildingContractor.Application.Stocks.Quieres.GetStockByContractorList
{
    public class GetStockByContractorMaterialDto : IMapWith<Material>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Material, GetStockByContractorMaterialDto>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name));
        }
    }
}
