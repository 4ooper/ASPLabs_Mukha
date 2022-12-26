namespace BuildingContractor.Domain
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Material> Materials { get; set; }
    }
}
