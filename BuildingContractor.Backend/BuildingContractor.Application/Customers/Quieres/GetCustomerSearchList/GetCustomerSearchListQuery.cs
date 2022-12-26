using MediatR;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerSearchList
{
    public class GetCustomerSearchListQuery : IRequest<GetCustomerSearchListVm>
    {
        public string SearchText { get; set; }
        public int Page { get; set; }
    }
}
