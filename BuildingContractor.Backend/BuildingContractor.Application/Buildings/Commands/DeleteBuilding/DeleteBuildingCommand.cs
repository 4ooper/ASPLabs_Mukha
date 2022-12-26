using MediatR;

namespace BuildingContractor.Application.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommand : IRequest
    {
        public int Id { get; set; }
    }
}
