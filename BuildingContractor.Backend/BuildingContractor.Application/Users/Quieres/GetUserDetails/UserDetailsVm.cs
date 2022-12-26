﻿using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;


namespace BuildingContractor.Application.Users.Quieres.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRoleLookupDto Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(entityDto => entityDto.Id, opt => opt.MapFrom(entity => entity.id))
                .ForMember(entityDto => entityDto.Login, opt => opt.MapFrom(entity => entity.Login))
                .ForMember(entityDto => entityDto.Role, opt => opt.MapFrom(entity => entity.Role));
        }
    }
}
