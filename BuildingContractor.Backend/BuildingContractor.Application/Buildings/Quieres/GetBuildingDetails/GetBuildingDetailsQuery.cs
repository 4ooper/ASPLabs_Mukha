using MediatR;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingDetails
{
    public class GetBuildingDetailsQuery : IRequest<GetBuildingDetailsVm>
    {
        public int Id { get; set; }
    }
}
