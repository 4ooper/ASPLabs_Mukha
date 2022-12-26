using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Buildings.Quieres.GetBuildingFilterList;

namespace BuildingContractor.WebAPI.Models
{
    public class BuildingFilterDto : IMapWith<GetBuildingFilterListQuery>
    {
        public int Page { get; set; }
        public int? CustomerId { get; set; }
        public int? ContractorId { get; set; }
        public string? SortProp { get; set; }
        public string? SortValue { get; set; }
        public DateTime? ConclusionDateStart { get; set; }
        public DateTime? ConclusionDateEnd { get; set; }
        public DateTime? DeliveryDateStart { get; set; }
        public DateTime? DeliveryDateEnd { get; set; }
        public DateTime? ComissioningDateStart { get; set; }
        public DateTime? ComissioningDateEnd { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BuildingFilterDto, GetBuildingFilterListQuery>()
                .ForMember(recordCommand => recordCommand.Page,
                    opt => opt.MapFrom(recordDto => recordDto.Page))
                .ForMember(recordCommand => recordCommand.CustomerId,
                    opt => opt.MapFrom(recordDto => recordDto.CustomerId))
                .ForMember(recordCommand => recordCommand.ContractorId,
                    opt => opt.MapFrom(recordDto => recordDto.ContractorId))
                .ForMember(recordCommand => recordCommand.ConclusionDateStart,
                    opt => opt.MapFrom(recordDto => recordDto.ConclusionDateStart))
                .ForMember(recordCommand => recordCommand.ConclusionDateEnd,
                    opt => opt.MapFrom(recordDto => recordDto.ConclusionDateEnd))
                .ForMember(recordCommand => recordCommand.DeliveryDateStart,
                    opt => opt.MapFrom(recordDto => recordDto.DeliveryDateStart))
                .ForMember(recordCommand => recordCommand.DeliveryDateEnd,
                    opt => opt.MapFrom(recordDto => recordDto.DeliveryDateEnd))
                .ForMember(recordCommand => recordCommand.ComissioningDateStart,
                    opt => opt.MapFrom(recordDto => recordDto.ComissioningDateStart))
                .ForMember(recordCommand => recordCommand.ComissioningDateEnd,
                    opt => opt.MapFrom(recordDto => recordDto.ComissioningDateEnd))
                .ForMember(recordCommand => recordCommand.SortValue,
                    opt => opt.MapFrom(recordDto => recordDto.SortValue))
                .ForMember(recordCommand => recordCommand.SortProp,
                    opt => opt.MapFrom(recordDto => recordDto.SortProp));
        }
    }
}
