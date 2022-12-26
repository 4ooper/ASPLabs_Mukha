namespace BuildingContractor.Domain
{
    public class Technic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public int ContractorId { get; set; }

        public Contractor Contractor { get; set; }
    }
}
