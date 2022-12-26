using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, Material>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateMaterialCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Material> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.materials.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.Id != request.Id)
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }

            entity.Result.Name = request.Name;
            entity.Result.CreationDate = request.CreationDate;
            entity.Result.Valid = request.Valid;
            entity.Result.ProducerId = request.ProducerId;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity.Result;
        }
    }
}
