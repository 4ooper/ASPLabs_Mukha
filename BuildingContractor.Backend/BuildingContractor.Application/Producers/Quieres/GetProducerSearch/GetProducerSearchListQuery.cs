using MediatR;

namespace BuildingContractor.Application.Producers.Quieres.GetProducerSearch
{
    public class GetProducerSearchListQuery : IRequest<ProducerSearchListVm>
    {
        public string searchText { get; set; }
    }
}
