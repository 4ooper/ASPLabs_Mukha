using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingSearchList
{
    public class GetBuildingSearchListLookupDto : IMapWith<Building>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ConclusionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ComissioningDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Building, GetBuildingSearchListLookupDto>()
                .ForMember(recordDto => recordDto.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordDto => recordDto.Name, opt => opt.MapFrom(record => record.Name))
                .ForMember(recordDto => recordDto.ConclusionDate, opt => opt.MapFrom(record => record.ConclusionDate))
                .ForMember(recordDto => recordDto.DeliveryDate, opt => opt.MapFrom(record => record.DeliveryDate))
                .ForMember(recordDto => recordDto.ComissioningDate, opt => opt.MapFrom(record => record.ComissioningDate));
        }
    }
}
