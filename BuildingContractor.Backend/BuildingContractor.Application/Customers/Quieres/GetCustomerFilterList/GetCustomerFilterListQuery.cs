using MediatR;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerFilterList
{
    public class GetCustomerFilterListQuery : IRequest<GetCustomerFilterListVm>
    {
        public int Page { get; set; }
        public string? SortProp { get; set; }
        public string? SortValue { get; set; }
    }
}
