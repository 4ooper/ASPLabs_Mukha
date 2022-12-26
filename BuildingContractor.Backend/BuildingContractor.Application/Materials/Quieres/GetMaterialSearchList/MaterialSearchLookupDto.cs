using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Materials.Quieres.GetMaterialSearchList
{
    public class MaterialSearchLookupDto : IMapWith<Material>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProducerMaterialSearchLookupDto Producer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Material, MaterialSearchLookupDto>()
                .ForMember(recordDto => recordDto.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordDto => recordDto.Name, opt => opt.MapFrom(record => record.Name))
                .ForMember(recordDto => recordDto.Producer, opt => opt.MapFrom(record => record.Producer));
        }
    }
}
