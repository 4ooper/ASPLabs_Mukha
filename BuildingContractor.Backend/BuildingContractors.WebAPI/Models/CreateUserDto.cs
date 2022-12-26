using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Users.Commands.CreateUser;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(entity => entity.Login,
                           opt => opt.MapFrom(entityDto => entityDto.Login))
                .ForMember(entity => entity.Password,
                           opt => opt.MapFrom(entityDto => entityDto.Password));
        }
    }
}
