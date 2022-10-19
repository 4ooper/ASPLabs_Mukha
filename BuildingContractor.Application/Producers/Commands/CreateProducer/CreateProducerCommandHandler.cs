using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Producers.Commands.CreateProducer
{
    public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, Producer>
    {
        private readonly INotesDbContext _dbcontext;

        public CreateProducerCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Producer> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            var producer = new Producer
            {
                name = request.name,
            };

            await _dbcontext.producers.AddAsync(producer, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return producer;
        }
    }
}
