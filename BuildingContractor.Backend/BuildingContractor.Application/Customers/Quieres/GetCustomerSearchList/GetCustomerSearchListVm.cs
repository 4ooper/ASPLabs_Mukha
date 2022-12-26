namespace BuildingContractor.Application.Customers.Quieres.GetCustomerSearchList
{
    public class GetCustomerSearchListVm
    {
        public IList<GetCustomerSearchLookupDto> Customers { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
