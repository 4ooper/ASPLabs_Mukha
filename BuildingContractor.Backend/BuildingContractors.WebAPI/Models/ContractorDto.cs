using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class ContractorDto : IMapWith<Contractor>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractorDto, Contractor>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name));
        }
    }
}
