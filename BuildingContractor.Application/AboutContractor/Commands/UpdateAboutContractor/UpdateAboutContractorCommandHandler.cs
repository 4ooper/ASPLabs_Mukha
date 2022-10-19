using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.AboutContractor.Commands.UpdateAboutContractor
{
    public class UpdateAboutContractorCommandHandler : IRequestHandler<UpdateAboutContractorCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateAboutContractorCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateAboutContractorCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.aboutContractor.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Domain.AboutContractor), request.id);
            }

            entity.Result.contractorID = request.contractorID;
            entity.Result.contractorStockID = request.contractorStockID;
            entity.Result.contractorTechniquesID = request.contractorTechniquesID;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
