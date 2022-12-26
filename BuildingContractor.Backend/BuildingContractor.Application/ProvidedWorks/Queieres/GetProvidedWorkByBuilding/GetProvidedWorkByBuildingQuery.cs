using MediatR;

namespace BuildingContractor.Application.ProvidedWorks.Queieres.GetProvidedWorkByBuilding
{
    public class GetProvidedWorkByBuildingQuery : IRequest<GetProvidedWorkByBuildingListVm>
    {
        public int BuildingId { get; set; }
    }
}
