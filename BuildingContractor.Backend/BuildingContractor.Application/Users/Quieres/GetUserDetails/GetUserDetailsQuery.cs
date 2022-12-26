using MediatR;

namespace BuildingContractor.Application.Users.Quieres.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public int id { get; set; }
    }
}
