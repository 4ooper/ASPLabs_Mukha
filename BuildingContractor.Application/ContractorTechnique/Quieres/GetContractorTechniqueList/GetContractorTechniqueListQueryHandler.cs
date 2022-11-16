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
            var records = await _dbcontext.contractorTechniques.Skip((request.page - 1) * 15).Take(15).ProjectTo<ContractorTechniqueLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.contractors.Count() / 15.0).ToString()));
            return new ContractorTechniqueListVm
            {
                contractorTechniques = records,
                next = request.page + 1 <= pagesCount ? $"https://{request.url.Value}/contractortechnique?page={request.page + 1}" : null,
                back = request.page - 1 > 0 ? $"https://{request.url.Value}/contractortechnique?page={request.page - 1}" : null,
                pagesCount = (int)pagesCount
            };
        }
    }
}
