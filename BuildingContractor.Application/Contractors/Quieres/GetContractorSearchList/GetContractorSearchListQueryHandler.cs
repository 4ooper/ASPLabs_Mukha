using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList
{
    public class GetContractorSearchListQueryHandler : IRequestHandler<GetContractorSearchListQuery, ContractorListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorListVm> Handle(GetContractorSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.contractors.Where(item => item.name.Contains(request.searchText)).Skip((request.page - 1) * 15).Take(15).ProjectTo<ContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.contractors.Count() / 15.0).ToString()));
            return new ContractorListVm
            {
                contractors = records,
                next = request.page + 1 <= pagesCount ? $"https://{request.url.Value}/contractors/Search?page={request.page + 1}&searchString={request.searchText}" : null,
                back = request.page - 1 > 0 ? $"https://{request.url.Value}/contractors/Search?page={request.page - 1}&searchString={request.searchText}" : null,
                pagesCount = (int)pagesCount
            };
        }
    }
}
