using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorList
{
    public class GetContractorListQueryHandler : IRequestHandler<GetContractorListQuery, ContractorListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        private readonly IMemoryCache _memoryCache;

        public GetContractorListQueryHandler(INotesDbContext dbContext, IMapper mapper, IMemoryCache memoryCache) => (_dbcontext, _mapper, _memoryCache) = (dbContext, mapper, memoryCache);

        public async Task<ContractorListVm> Handle(GetContractorListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.contractors.Skip((request.page - 1) * 15).Take(15).ProjectTo<ContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.contractors.Count() / 15.0).ToString()));
            return new ContractorListVm { 
                contractors = records,
                next = request.page + 1 <= pagesCount ? $"https://{request.url.Value}/contractors?page={request.page + 1}" : null,
                back = request.page - 1 > 0 ? $"https://{request.url.Value}/contractors?page={request.page - 1}" : null,
                pagesCount = (int)pagesCount
            };
        }
    }
}
