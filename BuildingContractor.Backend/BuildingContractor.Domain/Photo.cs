namespace BuildingContractor.Domain
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public int BuildingId { get; set; }

        public Building Building { get; set; }
    }
}
