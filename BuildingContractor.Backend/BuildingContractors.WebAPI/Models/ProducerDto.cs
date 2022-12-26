using AutoMapper;
using System;
using BuildingContractor.Domain;
using BuildingContractor.Application.Common.Mappings;

namespace BuildingContractor.WebAPI.Models
{
    public class ProducerDto : IMapWith<Producer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProducerDto, Producer>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name));
        }
    }
}
