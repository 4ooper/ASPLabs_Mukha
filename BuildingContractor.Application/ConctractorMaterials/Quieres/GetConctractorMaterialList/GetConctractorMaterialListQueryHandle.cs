using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Memory;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList
{
    public class GetConctractorMaterialListQueryHandle : IRequestHandler<GetConctractorMaterialListQuery, ConctractorMaterialVm>
    { 
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        private readonly IMemoryCache _memoryCache;
        private readonly int CachingTime = 284;

        public GetConctractorMaterialListQueryHandle(INotesDbContext dbContext, IMapper mapper, IMemoryCache memory) => (_dbcontext, _mapper, _memoryCache) = (dbContext, mapper, memory);

        public async Task<ConctractorMaterialVm> Handle(GetConctractorMaterialListQuery request, CancellationToken cancellationToken)
        {
            if (!_memoryCache.TryGetValue(request.cacheKey, out ConctractorMaterialVm materials))
            {
                var entities = await _dbcontext.conctractorMaterials.ProjectTo<ConctractorMaterialLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
                materials = new ConctractorMaterialVm { conctractorMaterials = entities };
                if (materials != null)
                {
                    _memoryCache.Set(request.cacheKey, materials,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }
            return materials;
        }
    }
}
