using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using BuildingContractor.Application.Materials.Commands.CreateMaterial;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateMaterialDto : IMapWith<CreateMaterialCommand>
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public ProducerMaterialDto producer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMaterialDto, CreateMaterialCommand>()
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name))
                .ForMember(recordCommand => recordCommand.CreationDate,
                    opt => opt.MapFrom(recordDto => recordDto.CreationDate))
                .ForMember(recordCommand => recordCommand.Valid,
                    opt => opt.MapFrom(recordDto => recordDto.Valid))
                .ForMember(recordCommand => recordCommand.ProducerId,
                    opt => opt.MapFrom(recordDto => recordDto.producer.Id));
        }
    }
}
