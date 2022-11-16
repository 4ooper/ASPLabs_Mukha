using MediatR;
using BuildingContractor.Domain;


namespace BuildingContractor.Application.AboutContractor.Commands.UpdateAboutContractor
{
    public class UpdateAboutContractorCommand : IRequest
    {
        public int id { get; set; }
        public int contractorID { get; set; }
        public int contractorStockID { get; set; }
        public int contractorTechniquesID { get; set; }
    }
}
