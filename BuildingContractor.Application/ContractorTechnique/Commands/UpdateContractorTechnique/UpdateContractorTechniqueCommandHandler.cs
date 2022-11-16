using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorTechnique.Commands.UpdateContractorTechnique
{
    public class UpdateContractorTechniqueCommandHandler : IRequestHandler<UpdateContractorTechniqueCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateContractorTechniqueCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateContractorTechniqueCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.contractorTechniques.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(ContractorTechniques), request.id);
            }

            entity.Result.name = request.name;
            entity.Result.buyDate = request.buyDate;
            entity.Result.validaty = request.validaty;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
