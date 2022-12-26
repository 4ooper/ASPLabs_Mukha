using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Commands.DeleteProducer
{
    public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteProducerCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.producers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Producer), request.Id);
            }

            _dbcontext.producers.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
