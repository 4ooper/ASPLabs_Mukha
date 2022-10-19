using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Photos.Commands.CreatePhoto;

namespace BuildingContractor.WebAPI.Models
{
    public class CreatePhotoDto : IMapWith<CreatePhotoCommand>
    {
        public string url { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePhotoDto, CreatePhotoCommand>()
                .ForMember(photoCommand => photoCommand.url,
                    opt => opt.MapFrom(photoDto => photoDto.url));
        }
    }
}
