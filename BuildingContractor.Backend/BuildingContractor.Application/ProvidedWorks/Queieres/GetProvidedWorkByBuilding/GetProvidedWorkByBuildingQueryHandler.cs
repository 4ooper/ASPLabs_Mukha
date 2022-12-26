using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.ProvidedWorks.Queieres.GetProvidedWorkByBuilding
{
    public class GetProvidedWorkByBuildingQueryHandler : IRequestHandler<GetProvidedWorkByBuildingQuery, GetProvidedWorkByBuildingListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetProvidedWorkByBuildingQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<GetProvidedWorkByBuildingListVm> Handle(GetProvidedWorkByBuildingQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.providedWorks.Where(item => item.BuildingId == request.BuildingId).ProjectTo<GetProvidedWorkByBuildingLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new GetProvidedWorkByBuildingListVm
            {
                ProvidedWorks = records
            };
        }
    }
}
