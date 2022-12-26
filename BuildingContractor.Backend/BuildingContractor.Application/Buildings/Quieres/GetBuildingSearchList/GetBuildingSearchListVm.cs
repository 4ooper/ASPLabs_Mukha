namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingSearchList
{
    public class GetBuildingSearchListVm
    {
        public IList<GetBuildingSearchListLookupDto> Buildings { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
