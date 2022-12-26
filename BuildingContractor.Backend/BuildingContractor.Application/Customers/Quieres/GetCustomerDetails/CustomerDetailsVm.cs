using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerDetails
{
    public class CustomerDetailsVm : IMapWith<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDetailsVm>()
                .ForMember(recordVm => recordVm.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordVm => recordVm.Name, opt => opt.MapFrom(record => record.Name));
        }
    }
}
    