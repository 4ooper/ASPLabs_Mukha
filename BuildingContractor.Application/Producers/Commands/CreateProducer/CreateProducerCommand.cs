using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Commands.CreateProducer
{
    public class CreateProducerCommand : IRequest<Producer>
    {
        public string name { get; set; }
    }
}
