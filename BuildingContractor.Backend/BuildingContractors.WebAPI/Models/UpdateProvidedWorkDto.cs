using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ProvidedWorks.Commands.UpdateProvidedWork;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateProvidedWorkDto : IMapWith<UpdateProvidedWorkCommand>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProvidedWorkDto, UpdateProvidedWorkCommand>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Description,
                    opt => opt.MapFrom(recordDto => recordDto.Description))
                .ForMember(recordCommand => recordCommand.Price,
                    opt => opt.MapFrom(recordDto => recordDto.Price))
                .ForMember(recordCommand => recordCommand.Discount,
                    opt => opt.MapFrom(recordDto => recordDto.Discount));
        }
    }
}
