using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.ProvidedWorks.Commands.CreateProvidedWork
{
    public class CreateProvidedWorkCommandHandler : IRequestHandler<CreateProvidedWorkCommand, ProvidedWork>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateProvidedWorkCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<ProvidedWork> Handle(CreateProvidedWorkCommand request, CancellationToken cancellationToken)
        {
            var record = new ProvidedWork
            {
                Description = request.Description,
                Price = request.Price,
                Discount = request.Discount,
                BuildingId = request.BuildingId
            };

            await _dbcontext.providedWorks.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
