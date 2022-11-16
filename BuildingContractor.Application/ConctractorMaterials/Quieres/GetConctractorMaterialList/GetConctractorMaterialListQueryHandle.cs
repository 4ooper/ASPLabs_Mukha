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
            var materials = await _dbcontext.conctractorMaterials.Skip((request.page - 1) * 15).Take(15).ProjectTo<ConctractorMaterialLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.contractors.Count() / 15.0).ToString()));
            return new ConctractorMaterialVm
            {
                conctractorMaterials = materials,
                next = request.page + 1 <= pagesCount ? $"https://{request.url.Value}/contractormaterials?page={request.page + 1}" : null,
                back = request.page - 1 > 0 ? $"https://{request.url.Value}/contractormaterials?page={request.page - 1}" : null,
                pagesCount = (int)pagesCount

            };
        }
    }
}
