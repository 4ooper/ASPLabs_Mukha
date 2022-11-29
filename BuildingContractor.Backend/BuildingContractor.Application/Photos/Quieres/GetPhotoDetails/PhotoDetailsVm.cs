using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Photos.Quieres.GetPhotoDetails
{
    public class PhotoDetailsVm : IMapWith<Photo>
    {
        public string url { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Photo, PhotoDetailsVm>()
                .ForMember(photoVm => photoVm.url, opt => opt.MapFrom(photo => photo.url));
        }
    }
}
