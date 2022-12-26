using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ProvidedWorks.Commands.UpdateProvidedWork
{
    public class UpdateProvidedWorkCommandHandler : IRequestHandler<UpdateProvidedWorkCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateProvidedWorkCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateProvidedWorkCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.providedWorks.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.Id != request.Id)
            {
                throw new NotFoundException(nameof(ProvidedWork), request.Id);
            }

            entity.Result.Description = request.Description;
            entity.Result.Price = request.Price;
            entity.Result.Discount = request.Discount;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
