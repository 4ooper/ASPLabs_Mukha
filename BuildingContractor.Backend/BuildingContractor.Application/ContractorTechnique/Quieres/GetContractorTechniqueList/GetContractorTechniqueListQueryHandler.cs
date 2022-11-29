using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList
{
    public class GetContractorTechniqueListQueryHandler : IRequestHandler<GetContractorTechniqueListQuery, ContractorTechniqueListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorTechniqueListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorTechniqueListVm> Handle(GetContractorTechniqueListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.contractorTechniques.Skip(request.page * 15).Take(15).ProjectTo<ContractorTechniqueLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.contractorTechniques.Count() / 15.0).ToString()));
            return new ContractorTechniqueListVm
            {
                contractorTechniques = records,
                totalElements = _dbcontext.contractorTechniques.Count(),
                pagesCount = (int)pagesCount
            };
        }
    }
}
