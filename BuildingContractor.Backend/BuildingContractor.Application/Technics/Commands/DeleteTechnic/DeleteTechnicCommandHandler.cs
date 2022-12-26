using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Technics.Commands.DeleteTechnic
{
    public class DeleteTechnicCommandHandler : IRequestHandler<DeleteTechnicCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteTechnicCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteTechnicCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.technics.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != entity.Id)
            {
                throw new NotFoundException(nameof(Technic), request.Id);
            }

            _dbcontext.technics.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
