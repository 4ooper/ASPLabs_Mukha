using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Photos.Commands.UpdatePhoto;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdatePhotoDto : IMapWith<UpdatePhotoCommand>
    {
        public int id { get; set; }
        public string url { get; set; }

        public void Mapping(Profile profile)
        {
            try
            {
                profile.CreateMap<UpdatePhotoDto, UpdatePhotoCommand>()
                .ForMember(photoCommand => photoCommand.id,
                    opt => opt.MapFrom(photoDto => photoDto.id))
                .ForMember(photoCommand => photoCommand.url,
                    opt => opt.MapFrom(photoDto => photoDto.url));
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception");
            }
        }
    }
}
