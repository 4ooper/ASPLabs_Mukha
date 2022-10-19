using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorList
{
    public class GetContractorListQueryHandler : IRequestHandler<GetContractorListQuery, ContractorListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorListVm> Handle(GetContractorListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.contractors.ProjectTo<ContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new ContractorListVm { contractors = records };
        }
    }
}
