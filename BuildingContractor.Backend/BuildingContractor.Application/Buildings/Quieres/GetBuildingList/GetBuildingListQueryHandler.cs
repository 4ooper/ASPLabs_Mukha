using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingList
{
    public class GetBuildingListQueryHandler : IRequestHandler<GetBuildingListQuery, GetBuildingListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        public GetBuildingListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<GetBuildingListVm> Handle(GetBuildingListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.buildings.Skip(request.Page * 15).Take(15).ProjectTo<GetBuildingListLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.buildings.Count() / 15.0).ToString()));
            return new GetBuildingListVm
            {
                Buildings = records,
                TotalElements = _dbcontext.buildings.Count(),
                MaxPage = (int)pagesCount
            };
        }
    }
}
