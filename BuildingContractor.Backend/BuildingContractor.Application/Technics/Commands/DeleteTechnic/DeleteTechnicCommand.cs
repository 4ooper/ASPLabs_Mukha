using MediatR;

namespace BuildingContractor.Application.Technics.Commands.DeleteTechnic
{
    public class DeleteTechnicCommand : IRequest
    {
        public int Id { get; set; }
    }
}
