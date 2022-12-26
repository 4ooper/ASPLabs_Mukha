using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ProvidedWorks.Commands.CreateProvidedWork
{
    public class CreateProvidedWorkCommand : IRequest<ProvidedWork>
    {
        public string Description { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public int BuildingId { get; set; }
    }
}
