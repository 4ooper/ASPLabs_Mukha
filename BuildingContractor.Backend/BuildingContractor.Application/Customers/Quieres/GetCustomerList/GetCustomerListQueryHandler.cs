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
            var customersQuery = await _dbcontext.customers.ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new CustomerListVm { customers = customersQuery };
        }
    }
}
