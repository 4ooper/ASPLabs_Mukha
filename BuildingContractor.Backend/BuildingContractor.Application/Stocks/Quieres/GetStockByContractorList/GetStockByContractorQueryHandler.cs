using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Stocks.Quieres.GetStockByContractorList
{
    public class GetStockByContractorQueryHandler : IRequestHandler<GetStockByContractorQuery, GetStockByContractorListVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetStockByContractorQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<GetStockByContractorListVm> Handle(GetStockByContractorQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.stock.Include(u => u.Material).Where(item => item.ContractorId == request.ContractorId).ProjectTo<GetStockByContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new GetStockByContractorListVm
            {
                Stock = records
            };
        }
    }
}
