using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.AboutContractor.Commands.DeleteAboutContractor
{
    public class DeleteAboutContractorCommandHandler : IRequestHandler<DeleteAboutContractorCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteAboutContractorCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteAboutContractorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.aboutContractor.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(Domain.AboutContractor), request.id);
            }

            _dbcontext.aboutContractor.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
