using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.ConctractorMaterials.Commands.CreateContractorMaterial
{
    public class CreateContractorMaterialCommandHandler : IRequestHandler<CreateContractorMaterialCommand, ConctractorMaterial>
    {
        private readonly INotesDbContext _dbcontext;

        public CreateContractorMaterialCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<ConctractorMaterial> Handle(CreateContractorMaterialCommand request, CancellationToken cancellationToken)
        {
            var record = new ConctractorMaterial
            {
                name = request.name,
                createdDate = request.createdDate,
                validaty = request.validaty,
                producerID = request.producer.id
            };

            await _dbcontext.conctractorMaterials.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
