namespace BuildingContractor.Domain
{
    public class Stock
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int MaterialId { get; set; }
        public int ContractorId { get; set; }

        public Material Material { get; set; }
        public Contractor Contractor { get; set; }
    }
}
