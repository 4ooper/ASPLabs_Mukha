using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Contractors.Commands.CreateContractor;
using System.ComponentModel.DataAnnotations;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateContractorDto : IMapWith<CreateContractorCommand>
    {
        [Required]
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractorDto, CreateContractorCommand>()
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name));
        }
    }
}
