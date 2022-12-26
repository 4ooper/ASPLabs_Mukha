using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Technics.Commands.CreateTechnic
{
    public class CreateTechnicCommandHandler : IRequestHandler<CreateTechnicCommand, Technic>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateTechnicCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Technic> Handle(CreateTechnicCommand request, CancellationToken cancellationToken)
        {
            var record = new Technic
            {
                Name = request.Name,
                CreationDate = request.CreationDate,
                Valid = request.Valid,
                ContractorId = request.ContractorId
            };

            await _dbcontext.technics.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
