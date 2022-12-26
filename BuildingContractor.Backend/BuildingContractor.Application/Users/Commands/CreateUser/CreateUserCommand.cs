using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
