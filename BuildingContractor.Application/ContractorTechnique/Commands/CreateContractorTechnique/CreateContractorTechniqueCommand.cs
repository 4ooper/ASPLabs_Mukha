using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorTechnique.Commands.CreateContractorTechnique
{
    public class CreateContractorTechniqueCommand : IRequest<ContractorTechniques>
    {
        public string name { get; set; }
        public DateTime buyDate { get; set; }
        public DateTime validaty { get; set; }
    }
}
