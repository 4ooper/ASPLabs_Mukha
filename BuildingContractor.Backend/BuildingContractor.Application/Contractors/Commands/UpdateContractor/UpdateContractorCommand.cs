using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
