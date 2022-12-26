namespace BuildingContractor.Application.Producers.Quieres.GetProducersSearchList
{
    public class ProducerSearchListVm
    {
        public IList<ProducerSearchLookupDto> Producers { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
