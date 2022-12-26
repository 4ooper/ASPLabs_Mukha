using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, CustomerListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetCustomerListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<CustomerListVm> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.customers.Skip(request.Page * 15).Take(15).ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.customers.Count() / 15.0).ToString()));
            return new CustomerListVm
            {
                Customers = records,
                TotalElements = _dbcontext.customers.Count(),
                MaxPage = (int)pagesCount
            };
        }
    }
}
