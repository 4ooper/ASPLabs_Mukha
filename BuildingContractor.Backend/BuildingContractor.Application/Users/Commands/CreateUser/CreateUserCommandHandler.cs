using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

namespace BuildingContractor.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateUserCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = String.Join("", md5.ComputeHash(Encoding.UTF8.GetBytes(request.Password)));
            }
            var user = new User
            {
                Login = request.Login,
                Password = hash,
                RoleId = 1
            };

            await _dbcontext.Users.AddAsync(user, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
