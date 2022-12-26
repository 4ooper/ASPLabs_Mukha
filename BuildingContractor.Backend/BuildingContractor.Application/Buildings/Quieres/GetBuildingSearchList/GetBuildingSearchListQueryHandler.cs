using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingSearchList
{
    public class GetBuildingSearchListQueryHandler : IRequestHandler<GetBuildingSearchListQuery, GetBuildingSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        public GetBuildingSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<GetBuildingSearchListVm> Handle(GetBuildingSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.buildings.Where(item => item.Name.Contains(request.SearchText)).Skip(request.Page * 15).Take(15).ProjectTo<GetBuildingSearchListLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.buildings.Where(item => item.Name.Contains(request.SearchText)).Count() / 15.0).ToString()));
            return new GetBuildingSearchListVm
            {
                Buildings = records,
                TotalElements = _dbcontext.buildings.Where(item => item.Name.Contains(request.SearchText)).Count(),
                MaxPage = (int)pagesCount
            };
        }
    }
}
