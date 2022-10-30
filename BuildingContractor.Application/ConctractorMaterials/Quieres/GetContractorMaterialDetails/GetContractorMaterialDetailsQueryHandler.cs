using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;
using AutoMapper.QueryableExtensions;


namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialDetails
{
    public class GetContractorMaterialDetailsQueryHandler : IRequestHandler<GetContractorMaterialDetailsQuery, ContractorMaterialDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetContractorMaterialDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorMaterialDetailsVm> Handle(GetContractorMaterialDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.conctractorMaterials.ProjectTo<ContractorMaterialDetailsVm>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(ConctractorMaterial), request.id);
            }

            return _mapper.Map<ContractorMaterialDetailsVm>(entity);
        }
    }
}
