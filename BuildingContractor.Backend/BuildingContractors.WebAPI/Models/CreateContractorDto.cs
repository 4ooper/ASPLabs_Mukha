using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Contractors.Commands.CreateContractor;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateContractorDto : IMapWith<CreateContractorCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractorDto, CreateContractorCommand>()
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name));
        }
    }
}
