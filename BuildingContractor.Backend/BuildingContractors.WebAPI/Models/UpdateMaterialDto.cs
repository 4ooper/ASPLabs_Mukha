using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Materials.Commands.UpdateMaterial;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateMaterialDto : IMapWith<UpdateMaterialCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public ProducerDto Producer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMaterialDto, UpdateMaterialCommand>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name))
                .ForMember(recordCommand => recordCommand.CreationDate,
                    opt => opt.MapFrom(recordDto => recordDto.CreationDate))
                .ForMember(recordCommand => recordCommand.Valid,
                    opt => opt.MapFrom(recordDto => recordDto.Valid))
                .ForMember(recordCommand => recordCommand.ProducerId,
                    opt => opt.MapFrom(recordDto => recordDto.Producer.Id));
        }
    }
}
