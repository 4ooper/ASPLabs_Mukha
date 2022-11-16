using MediatR;


namespace BuildingContractor.Application.Users.Quieres.GetUsersDetail
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public int id { get; set; }
    }
}
