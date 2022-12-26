using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Technics.Quieres.GetTechnicByContractorList
{
    public class GetTechnicByContractorQueryHandler : IRequestHandler<GetTechnicByContractorQuery, GetTechnicByContractorListVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetTechnicByContractorQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<GetTechnicByContractorListVm> Handle(GetTechnicByContractorQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.technics.Where(item => item.ContractorId == request.ContractorId).ProjectTo<GetTechnicByContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new GetTechnicByContractorListVm
            {
                Technics = records
            };
        }
    }
}
