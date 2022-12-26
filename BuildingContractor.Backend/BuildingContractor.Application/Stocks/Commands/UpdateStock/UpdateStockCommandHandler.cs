using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Stocks.Commands.UpdateStock
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, Stock>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateStockCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Stock> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.stock.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.Id != request.Id)
            {
                throw new NotFoundException(nameof(Stock), request.Id);
            }

            entity.Result.Count = request.Count;
            entity.Result.ContractorId = request.ContractorId;
            entity.Result.MaterialId = request.MaterialId;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity.Result;
        }
    }
}
