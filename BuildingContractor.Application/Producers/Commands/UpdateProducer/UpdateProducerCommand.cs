using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Commands.UpdateProducer
{
    public class UpdateProducerCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
