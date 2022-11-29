using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorList
{
    public class GetContractorListQueryHandler : IRequestHandler<GetContractorListQuery, ContractorListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorListVm> Handle(GetContractorListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.contractors.Skip(request.page * 15).Take(15).ProjectTo<ContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.contractors.Count() / 15.0).ToString()));
            return new ContractorListVm
            {
                contractors = records,
                totalElements = _dbcontext.producers.Count(),
                pagesCount = (int)pagesCount
            };
        }
    }
}
