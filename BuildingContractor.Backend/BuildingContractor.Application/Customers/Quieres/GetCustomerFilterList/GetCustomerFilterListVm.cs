namespace BuildingContractor.Application.Customers.Quieres.GetCustomerFilterList
{
    public class GetCustomerFilterListVm
    {
        public IList<GetCustomerFilterListLookupDto> Customers { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
