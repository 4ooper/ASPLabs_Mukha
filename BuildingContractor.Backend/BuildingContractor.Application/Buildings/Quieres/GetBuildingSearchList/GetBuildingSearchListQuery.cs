using MediatR;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingSearchList
{
    public class GetBuildingSearchListQuery : IRequest<GetBuildingSearchListVm>
    {
        public string SearchText { get; set; }
        public int Page { get; set; }
    }
}
