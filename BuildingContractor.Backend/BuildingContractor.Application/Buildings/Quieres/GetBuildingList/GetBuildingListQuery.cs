using MediatR;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingList
{
    public class GetBuildingListQuery : IRequest<GetBuildingListVm>
    {
        public int Page { get; set; }
    }
}
