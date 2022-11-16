using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string name { get; set; }
        public string surname { get; set; }
    }
}
