using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ConctractorMaterials.Commands.UpdateContractorMaterial
{
    public class UpdateContractorMaterialCommandHandler : IRequestHandler<UpdateContractorMaterialCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateContractorMaterialCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateContractorMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.conctractorMaterials.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(ConctractorMaterial), request.id);
            }

            entity.Result.name = request.name;
            entity.Result.createdDate = request.createdDate;
            entity.Result.validaty = request.validaty;
            entity.Result.producerID = request.ProducerID;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
