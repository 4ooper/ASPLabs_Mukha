using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Contractors.Commands.UpdateContractor;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateContractorDto : IMapWith<UpdateContractorCommand>
    {
        public int id { get; set; }
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractorDto, UpdateContractorCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name));
        }
    }
}
