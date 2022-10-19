using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockDetails
{
    public class GetContractorStockDetailsQueryHandler : IRequestHandler<GetContractorStockDetailsQuery, ContractorStockDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetContractorStockDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorStockDetailsVm> Handle(GetContractorStockDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.contractorStock.ProjectTo<ContractorStockDetailsVm>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(ContractorStock), request.id);
            }

            return _mapper.Map<ContractorStockDetailsVm>(entity);
        }
    }
}
