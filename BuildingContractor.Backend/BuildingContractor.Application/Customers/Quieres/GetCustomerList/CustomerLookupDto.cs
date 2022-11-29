using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerList
{
    public class CustomerLookupDto : IMapWith<Customer>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerLookupDto>()
                .ForMember(customerDto => customerDto.name, opt => opt.MapFrom(customer => customer.name))
                .ForMember(customerDto => customerDto.surname, opt => opt.MapFrom(customer => customer.surname));
        }
    }
}
