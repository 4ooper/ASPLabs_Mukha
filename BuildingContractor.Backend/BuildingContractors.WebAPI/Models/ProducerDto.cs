using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using BuildingContractor.Application.ContractorTechnique.Commands.UpdateContractorTechnique;

namespace BuildingContractor.WebAPI.Models
{
    public class ProducerDto : IMapWith<Producer>
    {
        public int id { get; set; }
        //public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProducerDto, Producer>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id));
                //.ForMember(customerCommand => customerCommand.name,
                //    opt => opt.MapFrom(customerDto => customerDto.name));
        }
    }
}
