using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorList
{
    public class GetAboutContractorListQueryHandler : IRequestHandler<GetAboutContractorListQuery, AboutContractorVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetAboutContractorListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<AboutContractorVm> Handle(GetAboutContractorListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.aboutContractor.ProjectTo<AboutContractorLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            return new AboutContractorVm { aboutContractors = records };
        }
    }
}
