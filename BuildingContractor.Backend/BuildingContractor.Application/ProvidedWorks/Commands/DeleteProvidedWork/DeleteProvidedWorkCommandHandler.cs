using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ProvidedWorks.Commands.DeleteProvidedWork
{
    public class DeleteProvidedWorkCommandHandler : IRequestHandler<DeleteProvidedWorkCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteProvidedWorkCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteProvidedWorkCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.providedWorks.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(ProvidedWork), request.Id);
            }

            _dbcontext.providedWorks.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
