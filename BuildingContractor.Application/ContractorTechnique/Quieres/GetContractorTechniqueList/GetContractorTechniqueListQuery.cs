using MediatR;
using Microsoft.AspNetCore.Http;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList
{
    public class GetContractorTechniqueListQuery : IRequest<ContractorTechniqueListVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
