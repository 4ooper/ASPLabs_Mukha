using MediatR;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingFilterList
{
    public class GetBuildingFilterListQuery : IRequest<GetBuildingFilterListVm>
    {
        public int Page { get; set; }
        public int? CustomerId { get; set; }
        public int? ContractorId { get; set; }
        public string? SortProp { get; set; }
        public string? SortValue { get; set; }
        public DateTime? ConclusionDateStart { get; set; }
        public DateTime? ConclusionDateEnd { get; set; }
        public DateTime? DeliveryDateStart { get; set; }
        public DateTime? DeliveryDateEnd { get; set; }
        public DateTime? ComissioningDateStart { get; set; }
        public DateTime? ComissioningDateEnd { get; set; }
    }
}
