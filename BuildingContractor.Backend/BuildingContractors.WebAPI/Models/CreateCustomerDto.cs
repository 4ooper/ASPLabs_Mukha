using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Customers.Commands.CreateCustomer;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateCustomerDto : IMapWith<CreateCustomerCommand>
    {
        public string name { get; set; }
        public string surname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCustomerDto, CreateCustomerCommand>()
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name))
                .ForMember(customerCommand => customerCommand.surname,
                    opt => opt.MapFrom(customerDto => customerDto.surname));
        }
    }
}
