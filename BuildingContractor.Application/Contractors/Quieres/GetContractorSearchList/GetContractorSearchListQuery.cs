using MediatR;
using Microsoft.AspNetCore.Http;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList
{
    public class GetContractorSearchListQuery : IRequest<ContractorListVm>
    {
        public string searchText { get; set; }
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
