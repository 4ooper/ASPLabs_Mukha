using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerSearchList
{
    public class GetCustomerSearchListQueryHandler : IRequestHandler<GetCustomerSearchListQuery, GetCustomerSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        public GetCustomerSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<GetCustomerSearchListVm> Handle(GetCustomerSearchListQuery request, CancellationToken cancellationToken)
        {
            List<GetCustomerSearchLookupDto> records;
            if(request.Page == -1)
            {
                records = await _dbcontext.customers.Where(item => item.Name.Contains(request.SearchText)).ProjectTo<GetCustomerSearchLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            }
            else
            {
                records = await _dbcontext.customers.Where(item => item.Name.Contains(request.SearchText)).Skip(request.Page * 15).Take(15).ProjectTo<GetCustomerSearchLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            }
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.customers.Where(item => item.Name.Contains(request.SearchText)).Count() / 15.0).ToString()));
            return new GetCustomerSearchListVm
            {
                Customers = records,
                TotalElements = _dbcontext.customers.Where(item => item.Name.Contains(request.SearchText)).Count(),
                MaxPage = (int)pagesCount
            };
        }
    }
}
