using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteStockCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.stock.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != entity.Id)
            {
                throw new NotFoundException(nameof(Stock), request.Id);
            }

            _dbcontext.stock.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
