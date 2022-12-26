using MediatR;

namespace BuildingContractor.Application.ProvidedWorks.Commands.UpdateProvidedWork
{
    public class UpdateProvidedWorkCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
    }
}
