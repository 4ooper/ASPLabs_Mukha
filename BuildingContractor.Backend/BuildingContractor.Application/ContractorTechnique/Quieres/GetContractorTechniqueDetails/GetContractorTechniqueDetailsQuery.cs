using MediatR;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueDetails
{
    public class GetContractorTechniqueDetailsQuery : IRequest<ContractorTechniqueDetailsVm>
    {
        public int id { get; set; }
    }
}
