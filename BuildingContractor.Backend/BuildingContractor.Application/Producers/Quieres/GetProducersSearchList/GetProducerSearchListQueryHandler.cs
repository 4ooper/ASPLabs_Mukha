using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersSearchList
{
    public class GetProducerSearchListQueryHandler : IRequestHandler<GetProducerSearchListQuery, ProducerSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        public GetProducerSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<ProducerSearchListVm> Handle(GetProducerSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.producers.Where(item => item.Name.Contains(request.SearchText)).Skip(request.Page * 15).Take(15).ProjectTo<ProducerSearchLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((records.Count() / 15.0).ToString()));
            return new ProducerSearchListVm
            {
                Producers = records,
                TotalElements = records.Count(),
                MaxPage = (int)pagesCount
            };
        }
    }
}
