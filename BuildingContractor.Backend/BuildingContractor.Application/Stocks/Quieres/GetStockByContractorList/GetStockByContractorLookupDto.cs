using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Common.Mappings;

namespace BuildingContractor.Application.Stocks.Quieres.GetStockByContractorList
{
    public class GetStockByContractorLookupDto : IMapWith<Stock>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public GetStockByContractorMaterialDto Material { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Stock, GetStockByContractorLookupDto>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Count,
                    opt => opt.MapFrom(recordDto => recordDto.Count));
        }
    }
}
