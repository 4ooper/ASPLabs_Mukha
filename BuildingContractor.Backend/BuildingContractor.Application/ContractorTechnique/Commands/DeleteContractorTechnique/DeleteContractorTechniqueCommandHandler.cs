using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorTechnique.Commands.DeleteContractorTechnique
{
    public class DeleteContractorTechniqueCommandHandler : IRequestHandler<DeleteContractorTechniqueCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteContractorTechniqueCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteContractorTechniqueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.contractorTechniques.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(Customer), request.id);
            }

            _dbcontext.contractorTechniques.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
