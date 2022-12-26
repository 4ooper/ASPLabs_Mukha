using MediatR;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersSearchList
{
    public class GetProducerSearchListQuery : IRequest<ProducerSearchListVm>
    {
        public int Page { get; set; }
        public string SearchText { get; set; }
    }
}
