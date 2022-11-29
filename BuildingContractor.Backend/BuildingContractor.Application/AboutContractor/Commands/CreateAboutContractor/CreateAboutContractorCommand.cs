using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.AboutContractor.Commands.CreateAboutContractor
{
    public class CreateAboutContractorCommand : IRequest<Domain.AboutContractor>
    {
        public int contractorID { get; set; }
        public int contractorStockID { get; set; }
        public int contractorTechniquesID { get; set; }
    }
}
