using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Producers.Commands.UpdateProducer;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateProducerDto : IMapWith<UpdateProducerCommand>
    {
        public int id { get; set; }
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProducerDto, UpdateProducerCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name));
        }
    }
}
