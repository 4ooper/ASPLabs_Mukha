using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Materials.Quieres.GetMaterialDetails
{
    public class GetMaterialDetailsQueryHandler : IRequestHandler<GetMaterialDetailsQuery, MaterialDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetMaterialDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<MaterialDetailsVm> Handle(GetMaterialDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.materials.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }

            return _mapper.Map<MaterialDetailsVm>(entity);
        }
    }
}
