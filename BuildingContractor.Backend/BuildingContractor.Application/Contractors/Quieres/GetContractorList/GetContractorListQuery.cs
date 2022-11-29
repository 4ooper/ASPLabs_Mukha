using MediatR;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorList
{
    public class GetContractorListQuery : IRequest<ContractorListVm>
    {
        public int page { get; set; }
    }
}
