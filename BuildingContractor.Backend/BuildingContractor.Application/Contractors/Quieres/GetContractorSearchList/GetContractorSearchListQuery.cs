using MediatR;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList
{
    public class GetContractorSearchListQuery : IRequest<ContractorSearchListVm>
    {
        public string SearchText { get; set; }
        public int Page { get; set; }
    }
}
