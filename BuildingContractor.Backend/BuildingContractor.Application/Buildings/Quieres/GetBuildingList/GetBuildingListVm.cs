namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingList
{
    public class GetBuildingListVm
    {
        public IList<GetBuildingListLookupDto> Buildings { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
