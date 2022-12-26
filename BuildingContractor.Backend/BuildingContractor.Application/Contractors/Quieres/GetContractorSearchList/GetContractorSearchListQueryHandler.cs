using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Application.Contractors.Quieres.GetContractorList;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList
{
    public class GetContractorSearchListQueryHandler : IRequestHandler<GetContractorSearchListQuery, ContractorSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorSearchListVm> Handle(GetContractorSearchListQuery request, CancellationToken cancellationToken)
        {
            List<ContractorLookupDto> records;
            if (request.Page == -1)
            {
                records = await _dbcontext.contractors.Where(item => item.Name.Contains(request.SearchText)).ProjectTo<ContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            }
            else
            {
                records = await _dbcontext.contractors.Where(item => item.Name.Contains(request.SearchText)).Skip(request.Page * 15).Take(15).ProjectTo<ContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            }
            var totalFindElements = _dbcontext.contractors.Where(item => item.Name.Contains(request.SearchText)).Count();
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.contractors.Where(item => item.Name.Contains(request.SearchText)).Count() / 15.0).ToString()));
            return new ContractorSearchListVm
            {
                Contractors = records,
                TotalElements = totalFindElements,
                MaxPage = (int)pagesCount
            };
        }
    }
}
