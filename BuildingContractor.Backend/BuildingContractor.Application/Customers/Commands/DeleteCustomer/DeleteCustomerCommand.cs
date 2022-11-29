using MediatR;

namespace BuildingContractor.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public int id { get; set; }
    }
}
