using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ProvidedWorks.Commands.CreateProvidedWork;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateProvidedWorkDto : IMapWith<CreateProvidedWorkCommand>
    {
        public string Description { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public BuildingDto Building { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProvidedWorkDto, CreateProvidedWorkCommand>()
                .ForMember(recordCommand => recordCommand.Description,
                    opt => opt.MapFrom(recordDto => recordDto.Description))
                .ForMember(recordCommand => recordCommand.Price,
                    opt => opt.MapFrom(recordDto => recordDto.Price))
                .ForMember(recordCommand => recordCommand.Discount,
                    opt => opt.MapFrom(recordDto => recordDto.Discount))
                .ForMember(recordCommand => recordCommand.BuildingId,
                    opt => opt.MapFrom(recordDto => recordDto.Building.Id));
        }
    }
}
