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
            var records = await _dbcontext.conctractorMaterials.Skip(request.page * 15).Take(15).ProjectTo<ConctractorMaterialLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.producers.Count() / 15.0).ToString()));
            return new ConctractorMaterialVm
            {
                conctractorMaterials = records,
                totalElements = _dbcontext.producers.Count(),
                pagesCount = (int)pagesCount
            };
        }
    }
}
