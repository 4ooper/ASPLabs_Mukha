namespace BuildingContractor.Application.Contractors.Quieres.GetContractorFilterList
{
    public class GetContractorFilterListVm
    {
        public IList<GetContractorFilterListLookupDto> Contractors { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
