namespace BuildingContractor.Application.Customers.Quieres.GetCustomerList
{
    public class CustomerListVm
    {
        public IList<CustomerLookupDto> Customers { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
