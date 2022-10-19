using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommand : IRequest<Contractor>
    {
        public string name { get; set; }
    }
}
