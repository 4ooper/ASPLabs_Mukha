using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Common.Mappings;

namespace BuildingContractor.Application.Technics.Quieres.GetTechnicByContractorList
{
    public class GetTechnicByContractorLookupDto : IMapWith<Technic>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Technic, GetTechnicByContractorLookupDto>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name))
                .ForMember(recordCommand => recordCommand.CreationDate,
                    opt => opt.MapFrom(recordDto => recordDto.CreationDate))
                .ForMember(recordCommand => recordCommand.Valid,
                    opt => opt.MapFrom(recordDto => recordDto.Valid));
        }
    }
}
