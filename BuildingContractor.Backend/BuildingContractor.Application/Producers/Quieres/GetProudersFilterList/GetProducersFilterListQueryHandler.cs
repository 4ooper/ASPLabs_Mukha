using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Quieres.GetProudersFilterList
{
    public class GetProducersFilterListQueryHandler : IRequestHandler<GetProducersFilterListQuery, GetProducersFilterListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        public GetProducersFilterListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<GetProducersFilterListVm> Handle(GetProducersFilterListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Producer> records = _dbcontext.producers;
            if(request.SortValue != null)
            {
                switch(request.SortValue.ToLower())
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

            var result = await records.Skip(request.Page * 15).Take(15).ProjectTo<GetProducersFilterListLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((records.Count() / 15.0).ToString()));
            return new GetProducersFilterListVm
            {
                Producers = result,
                TotalElements = records.Count(),
                MaxPage = (int)pagesCount
            };
        }
    }
}
