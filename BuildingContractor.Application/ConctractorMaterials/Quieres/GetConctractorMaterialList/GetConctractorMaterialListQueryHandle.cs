using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList
{
    public class GetConctractorMaterialListQueryHandle : IRequestHandler<GetConctractorMaterialListQuery, ConctractorMaterialVm>
    { 
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetConctractorMaterialListQueryHandle(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ConctractorMaterialVm> Handle(GetConctractorMaterialListQuery request, CancellationToken cancellationToken)
        {
            var materials = await _dbcontext.conctractorMaterials.ProjectTo<ConctractorMaterialLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            return new ConctractorMaterialVm { conctractorMaterials = materials };
        }
    }
}
