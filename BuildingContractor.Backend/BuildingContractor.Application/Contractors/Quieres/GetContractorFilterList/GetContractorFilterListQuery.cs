using MediatR;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorFilterList
{
    public class GetContractorFilterListQuery : IRequest<GetContractorFilterListVm>
    {
        public int Page { get; set; }
        public string? SortProp { get; set; }
        public string? SortValue { get; set; }
    }
}
