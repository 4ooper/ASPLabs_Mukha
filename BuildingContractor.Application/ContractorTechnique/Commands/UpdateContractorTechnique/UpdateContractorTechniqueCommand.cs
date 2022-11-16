using MediatR;
using BuildingContractor.Domain;


namespace BuildingContractor.Application.ContractorTechnique.Commands.UpdateContractorTechnique
{
    public class UpdateContractorTechniqueCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime buyDate { get; set; }
        public DateTime validaty { get; set; }
    }
}
