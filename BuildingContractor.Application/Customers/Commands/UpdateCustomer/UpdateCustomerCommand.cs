using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}
