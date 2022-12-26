using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, Material>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateMaterialCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Material> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var record = new Material
            {
                Name = request.Name,
                CreationDate = request.CreationDate,
                Valid = request.Valid,
                ProducerId = request.ProducerId
            };

            await _dbcontext.materials.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
