namespace BuildingContractor.Domain
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
        public IList<Stock> Stocks { get; set; }
    }
}
