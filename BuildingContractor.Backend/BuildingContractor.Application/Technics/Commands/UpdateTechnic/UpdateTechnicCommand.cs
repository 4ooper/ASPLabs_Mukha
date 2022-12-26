using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Technics.Commands.UpdateTechnic
{
    public class UpdateTechnicCommand : IRequest<Technic>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public int ContractorId { get; set; }
    }
}
