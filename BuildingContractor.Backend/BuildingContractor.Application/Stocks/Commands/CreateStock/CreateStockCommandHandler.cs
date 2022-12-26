using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Stocks.Commands.CreateStock
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, Stock>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateStockCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Stock> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var record = new Stock
            {
                Count = request.Count,
                ContractorId = request.ContractorId,
                MaterialId = request.MaterialId
            };

            await _dbcontext.stock.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
