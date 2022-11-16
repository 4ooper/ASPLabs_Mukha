using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueDetails
{
    public class GetContractorTechniqueDetailsQueryHandler : IRequestHandler<GetContractorTechniqueDetailsQuery, ContractorTechniqueDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetContractorTechniqueDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorTechniqueDetailsVm> Handle(GetContractorTechniqueDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.contractorTechniques.FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(ContractorTechniques), request.id);
            }

            return _mapper.Map<ContractorTechniqueDetailsVm>(entity);
        }
    }
}
