using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ConctractorMaterials.Commands.DeleteContractorMaterial
{
    public class DeleteContractorMaterialCommandHandler : IRequestHandler<DeleteContractorMaterialCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteContractorMaterialCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteContractorMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.conctractorMaterials.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(ConctractorMaterial), request.id);
            }

            _dbcontext.conctractorMaterials.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
