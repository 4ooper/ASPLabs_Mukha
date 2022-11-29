using MediatR;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersList
{
    public class GetProducerListQuery : IRequest<ProducerListVm>
    {
        public int page { get; set; }
    }
}
