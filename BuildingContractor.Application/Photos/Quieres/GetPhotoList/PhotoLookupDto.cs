using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Photos.Quieres.GetPhotoList
{
    public class PhotoLookupDto : IMapWith<Photo>
    {
        public int id { get; set; }
        public string url { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Photo, PhotoLookupDto>()
                .ForMember(photoDto => photoDto.id, opt => opt.MapFrom(photo => photo.id))
                .ForMember(photoDto => photoDto.url, opt => opt.MapFrom(photo => photo.url));
        }
    }
}
