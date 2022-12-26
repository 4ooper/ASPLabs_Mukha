using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Materials.Quieres.GetMaterialSearchList
{
    public class GetMaterialSearchListQueryHandler : IRequestHandler<GetMaterialSearchListQuery, MaterialSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetMaterialSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<MaterialSearchListVm> Handle(GetMaterialSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.materials.Include(u => u.Producer).Where(item => item.Name.Contains(request.SearchText)).ProjectTo<MaterialSearchLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new MaterialSearchListVm
            {
                Materials = records
            };
        }
    }
}
