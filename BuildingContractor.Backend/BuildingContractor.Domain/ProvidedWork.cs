namespace BuildingContractor.Domain
{
    public class ProvidedWork
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public int BuildingId { get; set; }

        public Building Building { get; set; }
    }
}
