using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorStocks.Commands.DeleteContractorStock
{
    public class DeleteContractorStockCommandHandler : IRequestHandler<DeleteContractorStockCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteContractorStockCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteContractorStockCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.contractorStock.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(ContractorStock), request.id);
            }

            _dbcontext.contractorStock.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
