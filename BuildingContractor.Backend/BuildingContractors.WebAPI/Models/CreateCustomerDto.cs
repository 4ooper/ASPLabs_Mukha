using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Customers.Commands.CreateCustomer;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateCustomerDto : IMapWith<CreateCustomerCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCustomerDto, CreateCustomerCommand>()
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name));
        }
    }
}
