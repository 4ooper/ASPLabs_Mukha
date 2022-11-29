using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Producers.Quieres.GetProducerSearch
{
    public class GetProducerSearchListQueryHandler : IRequestHandler<GetProducerSearchListQuery, ProducerSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetProducerSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ProducerSearchListVm> Handle(GetProducerSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.producers.Where(item => item.name.Contains(request.searchText)).ProjectTo<ProducerSearchLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new ProducerSearchListVm
            {
                producers = records
            };
        }
    }
}
