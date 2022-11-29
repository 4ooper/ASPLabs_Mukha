using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersList
{
    public class GetProducerListQueryHandle : IRequestHandler<GetProducerListQuery, ProducerListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetProducerListQueryHandle(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ProducerListVm> Handle(GetProducerListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.producers.Skip(request.page * 15).Take(15).ProjectTo<ProducerLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.producers.Count() / 15.0).ToString()));
            return new ProducerListVm
            {
                producers = records,
                totalElements = _dbcontext.producers.Count(),
                pagesCount = (int)pagesCount
            };
        }
    }
}
