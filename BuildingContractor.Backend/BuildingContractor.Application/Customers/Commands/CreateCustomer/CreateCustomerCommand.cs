using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string Name { get; set; }
    }
}
