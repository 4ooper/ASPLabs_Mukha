using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Photos.Commands.CreatePhoto;

namespace BuildingContractor.WebAPI.Models
{
    public class CreatePhotoDto : IMapWith<CreatePhotoCommand>
    {
        public IFormFile Photo { get; set; }
        public int BuildingId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePhotoDto, CreatePhotoCommand>()
                .ForMember(recordCommand => recordCommand.Photo,
                    opt => opt.MapFrom(recordDto => recordDto.Photo))
                .ForMember(recordCommand => recordCommand.BuildingId,
                    opt => opt.MapFrom(recordDto => recordDto.BuildingId));
        }
    }
}
