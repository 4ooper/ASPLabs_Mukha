namespace BuildingContractor.Domain
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public DateTime ConclusionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ComissioningDate { get; set; }

        public IList<Photo> Photos { get; set; }
        public IList<ProvidedWork> ProvidedWorks { get; set; }
    }
}
