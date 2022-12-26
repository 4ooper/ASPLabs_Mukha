using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommand : IRequest<Building>
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public int ContractorId { get; set; }
        public DateTime ConclusionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ComissioningDate { get; set; }
    }
}
