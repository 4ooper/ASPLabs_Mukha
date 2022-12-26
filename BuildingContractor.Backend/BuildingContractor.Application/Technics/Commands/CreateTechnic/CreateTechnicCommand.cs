using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Technics.Commands.CreateTechnic
{
    public class CreateTechnicCommand : IRequest<Technic>
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public int ContractorId { get; set; }
    }
}
