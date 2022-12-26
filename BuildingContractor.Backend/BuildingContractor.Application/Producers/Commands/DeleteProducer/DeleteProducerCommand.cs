using MediatR;

namespace BuildingContractor.Application.Producers.Commands.DeleteProducer
{
    public class DeleteProducerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
