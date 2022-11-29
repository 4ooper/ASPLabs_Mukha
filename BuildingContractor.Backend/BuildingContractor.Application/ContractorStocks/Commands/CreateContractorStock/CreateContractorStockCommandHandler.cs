using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.ContractorStocks.Commands.CreateContractorStock
{
    public class CreateContractorStockCommandHandler : IRequestHandler<CreateContractorStockCommand, ContractorStock>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateContractorStockCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<ContractorStock> Handle(CreateContractorStockCommand request, CancellationToken cancellationToken)
        {
            var record = new ContractorStock
            {
                count = request.count,
                price = request.price,
                contractorMaterialID = request.conctractorMaterial.id
            };

            await _dbcontext.contractorStock.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
