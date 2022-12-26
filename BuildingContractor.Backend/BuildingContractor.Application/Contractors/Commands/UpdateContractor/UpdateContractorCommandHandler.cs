using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommandHandler : IRequestHandler<UpdateContractorCommand>
    {
        private readonly INotesDbContext _dbcontext;

        public UpdateContractorCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;

        public async Task<Unit> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.contractors.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.Id != request.Id)
            {
                throw new NotFoundException(nameof(Contractor), request.Id);
            }

            entity.Result.Name = request.Name;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
