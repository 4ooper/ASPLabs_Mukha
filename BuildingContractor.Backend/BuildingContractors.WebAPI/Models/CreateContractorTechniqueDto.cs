using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ContractorTechnique.Commands.CreateContractorTechnique;
using System.ComponentModel.DataAnnotations;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateContractorTechniqueDto : IMapWith<CreateContractorTechniqueCommand>
    {
        [Required]
        public string name { get; set; }
        [Required]
        public DateTime buyDate { get; set; }
        [Required]
        public DateTime validaty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractorTechniqueDto, CreateContractorTechniqueCommand>()
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name))
                .ForMember(customerCommand => customerCommand.buyDate,
                    opt => opt.MapFrom(customerDto => customerDto.buyDate))
                .ForMember(customerCommand => customerCommand.validaty,
                    opt => opt.MapFrom(customerDto => customerDto.validaty));
        }
    }
}
