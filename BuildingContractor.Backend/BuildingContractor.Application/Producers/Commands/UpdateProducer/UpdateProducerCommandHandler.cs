using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Commands.UpdateProducer
{
    public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateProducerCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.producers.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.Id != request.Id)
            {
                throw new NotFoundException(nameof(Producer), request.Id);
            }

            entity.Result.Name = request.Name;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
