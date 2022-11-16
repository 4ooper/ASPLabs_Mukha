using MediatR;
using Microsoft.AspNetCore.Http;

namespace BuildingContractor.Application.Users.Quieres.GetUsersList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
