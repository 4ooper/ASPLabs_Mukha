using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Users.Commands.SignInUser
{
    public class SignInUserCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
