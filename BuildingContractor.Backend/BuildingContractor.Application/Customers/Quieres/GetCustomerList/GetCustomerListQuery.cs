using MediatR;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<CustomerListVm>
    {
        public int Page { get; set; }
    }
}
