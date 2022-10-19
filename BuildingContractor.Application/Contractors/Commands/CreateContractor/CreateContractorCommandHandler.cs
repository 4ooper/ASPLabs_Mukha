using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, Contractor>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateContractorCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Contractor> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
        {
            var record = new Contractor
            {
                name = request.name
            };

            await _dbcontext.contractors.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
