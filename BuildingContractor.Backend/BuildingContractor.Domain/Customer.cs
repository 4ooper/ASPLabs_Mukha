namespace BuildingContractor.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Building> Buildings { get; set; }
    }
}
