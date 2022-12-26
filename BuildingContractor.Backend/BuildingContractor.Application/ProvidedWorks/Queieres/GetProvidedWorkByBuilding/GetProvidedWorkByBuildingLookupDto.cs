using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ProvidedWorks.Queieres.GetProvidedWorkByBuilding
{
    public class GetProvidedWorkByBuildingLookupDto : IMapWith<ProvidedWork>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProvidedWork, GetProvidedWorkByBuildingLookupDto>()
                .ForMember(recordDto => recordDto.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordDto => recordDto.Description, opt => opt.MapFrom(record => record.Description))
                .ForMember(recordDto => recordDto.Price, opt => opt.MapFrom(record => record.Price))
                .ForMember(recordDto => recordDto.Discount, opt => opt.MapFrom(record => record.Discount));
        }
    }
}
