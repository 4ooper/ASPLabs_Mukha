using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerFilterList
{
    public class GetCustomerFilterListQueryHandler : IRequestHandler<GetCustomerFilterListQuery, GetCustomerFilterListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        public GetCustomerFilterListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<GetCustomerFilterListVm> Handle(GetCustomerFilterListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Customer> records = _dbcontext.customers;
            if (request.SortValue != null)
            {
                switch (request.SortValue.ToLower())
                {
                    case "id":
                        records = records.OrderBy(x => x.Id);
                        break;
                    case "name":
                        records = records.OrderBy(x => x.Name);
                        break;
                    default:
                        records = records.OrderBy(x => x.Id);
                        break;
                }
                if (request.SortValue.ToLower() == "desc")
                {
                    records = records.Reverse();
                }
            }

            var result = await records.Skip(request.Page * 15).Take(15).ProjectTo<GetCustomerFilterListLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((records.Count() / 15.0).ToString()));
            return new GetCustomerFilterListVm
            {
                Customers = result,
                TotalElements = records.Count(),
                MaxPage = (int)pagesCount
            };
        }
    }
}
