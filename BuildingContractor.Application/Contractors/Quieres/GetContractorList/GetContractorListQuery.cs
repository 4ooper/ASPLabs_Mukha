using MediatR;
using Microsoft.AspNetCore.Http;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorList
{
    public class GetContractorListQuery : IRequest<ContractorListVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
