using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
