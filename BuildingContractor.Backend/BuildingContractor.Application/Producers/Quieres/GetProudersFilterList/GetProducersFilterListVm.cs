namespace BuildingContractor.Application.Producers.Quieres.GetProudersFilterList
{
    public class GetProducersFilterListVm
    {
        public IList<GetProducersFilterListLookupDto> Producers { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
