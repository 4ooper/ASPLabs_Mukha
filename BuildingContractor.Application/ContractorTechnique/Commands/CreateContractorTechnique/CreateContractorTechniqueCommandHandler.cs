using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.ContractorTechnique.Commands.CreateContractorTechnique
{
    public class CreateContractorTechniqueCommandHandler : IRequestHandler<CreateContractorTechniqueCommand, ContractorTechniques>
    {
        private readonly INotesDbContext _dbcontext;

        public CreateContractorTechniqueCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<ContractorTechniques> Handle(CreateContractorTechniqueCommand request, CancellationToken cancellationToken)
        {
            var record = new ContractorTechniques
            {
                name = request.name,
                buyDate = request.buyDate,
                validaty = request.validaty
            };

            await _dbcontext.contractorTechniques.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
