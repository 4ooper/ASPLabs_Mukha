using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorStocks.Commands.UpdateContractorStock
{
    public class UpdateContractorStockCommandHandler : IRequestHandler<UpdateContractorStockCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateContractorStockCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateContractorStockCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.contractorStock.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(ContractorStock), request.id);
            }

            entity.Result.count = request.count;
            entity.Result.price = request.price;
            entity.Result.contractorMaterialID = request.contractorMaterial.id;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
