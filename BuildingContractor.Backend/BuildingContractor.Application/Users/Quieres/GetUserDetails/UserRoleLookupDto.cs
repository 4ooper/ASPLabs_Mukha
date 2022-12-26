using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Users.Quieres.GetUserDetails
{
    public class UserRoleLookupDto : IMapWith<UserRole>
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRole, UserRoleLookupDto>()
                .ForMember(entityDto => entityDto.Id, opt => opt.MapFrom(entity => entity.id))
                .ForMember(entityDto => entityDto.Role, opt => opt.MapFrom(entity => entity.Role));
        }
    }
}
