namespace BuildingContractor.Application.Producers.Quieres.GetProducersList
{
    public class ProducerListVm
    {
        public IList<ProducerLookupDto> Producers { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
