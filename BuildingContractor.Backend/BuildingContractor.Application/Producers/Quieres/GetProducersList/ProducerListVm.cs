namespace BuildingContractor.Application.Producers.Quieres.GetProducersList
{
    public class ProducerListVm
    {
        public IList<ProducerLookupDto> producers { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
