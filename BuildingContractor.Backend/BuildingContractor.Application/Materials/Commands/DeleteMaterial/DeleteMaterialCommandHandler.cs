using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteMaterialCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.materials.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != entity.Id)
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }

            _dbcontext.materials.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
