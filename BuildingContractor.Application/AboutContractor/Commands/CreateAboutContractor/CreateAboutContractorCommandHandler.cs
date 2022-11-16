using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.AboutContractor.Commands.CreateAboutContractor
{
    public class CreateAboutContractorCommandHandler : IRequestHandler<CreateAboutContractorCommand, Domain.AboutContractor>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateAboutContractorCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Domain.AboutContractor> Handle(CreateAboutContractorCommand request, CancellationToken cancellationToken)
        {
            var record = new Domain.AboutContractor
            {
                contractorID = request.contractorID,
                contractorStockID = request.contractorStockID,
                contractorTechniquesID = request.contractorTechniquesID,
            };

            await _dbcontext.aboutContractor.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
