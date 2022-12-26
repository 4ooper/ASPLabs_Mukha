using MediatR;

namespace BuildingContractor.Application.Producers.Commands.UpdateProducer
{
    public class UpdateProducerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
