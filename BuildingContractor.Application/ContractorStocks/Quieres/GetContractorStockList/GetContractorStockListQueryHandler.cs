using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockList
{
    public class GetContractorStockListQueryHandler : IRequestHandler<GetContractorStockListQuery, ContractorStockVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorStockListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorStockVm> Handle(GetContractorStockListQuery request, CancellationToken cancellationToken)
        {
            var stock = await _dbcontext.contractorStock.ProjectTo<ContractorStockLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            return new ContractorStockVm { contractorStock = stock };
        }
    }
}
