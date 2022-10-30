using MediatR;

namespace BuildingContractor.Application.AboutContractor.Commands.DeleteAboutContractor
{
    public class DeleteAboutContractorCommand : IRequest
    {
        public int id { get; set; }
    }
}
