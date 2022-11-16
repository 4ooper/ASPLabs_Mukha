using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ContractorTechnique.Commands.UpdateContractorTechnique;

namespace WebApplication.Models
{
    public class UpdateContractorTechniqueDto : IMapWith<UpdateContractorTechniqueCommand>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime buyDate { get; set; }
        public DateTime validaty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractorTechniqueDto, UpdateContractorTechniqueCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name))
                .ForMember(customerCommand => customerCommand.buyDate,
                    opt => opt.MapFrom(customerDto => customerDto.buyDate))
                .ForMember(customerCommand => customerCommand.validaty,
                    opt => opt.MapFrom(customerDto => customerDto.validaty));
        }
    }
}
