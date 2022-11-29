using MediatR;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList
{
    public class GetContractorTechniqueListQuery : IRequest<ContractorTechniqueListVm>
    {
        public int page { get; set; }
    }
}
