using MediatR;

namespace BuildingContractor.Application.ContractorTechnique.Commands.DeleteContractorTechnique
{
    public class DeleteContractorTechniqueCommand : IRequest
    {
        public int id { get; set; }
    }
}
