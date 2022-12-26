using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorFilterList
{
    public class GetContractorFilterListLookupDto : IMapWith<Contractor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contractor, GetContractorFilterListLookupDto>()
                .ForMember(recordDto => recordDto.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordDto => recordDto.Name, opt => opt.MapFrom(record => record.Name));
        }
    }
}
