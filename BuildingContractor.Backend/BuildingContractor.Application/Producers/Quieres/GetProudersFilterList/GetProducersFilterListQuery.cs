using MediatR;

namespace BuildingContractor.Application.Producers.Quieres.GetProudersFilterList
{
    public class GetProducersFilterListQuery : IRequest<GetProducersFilterListVm>
    {
        public int Page { get; set; }
        public string? SortProp { get; set; }
        public string? SortValue { get; set; }
    }
}
