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
            var entity = _dbcontext.producers.FirstOrDefaultAsync(producer => producer.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Producer), request.id);
            }

            entity.Result.name = request.name;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
