using MediatR;

namespace BuildingContractor.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int id { get; set; }
    }
}
