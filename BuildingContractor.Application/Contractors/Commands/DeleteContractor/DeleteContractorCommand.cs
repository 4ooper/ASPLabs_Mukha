using MediatR;

namespace BuildingContractor.Application.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommand : IRequest
    {
        public int id { get; set; }
    }
}
