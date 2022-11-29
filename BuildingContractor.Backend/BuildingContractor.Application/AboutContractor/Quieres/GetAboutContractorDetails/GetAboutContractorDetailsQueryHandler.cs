using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorDetails
{
    public class GetAboutContractorDetailsQueryHandler : IRequestHandler<GetAboutContractorDetailsQuery, AboutContractorDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetAboutContractorDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<AboutContractorDetailsVm> Handle(GetAboutContractorDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.aboutContractor.ProjectTo<AboutContractorDetailsVm>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Domain.AboutContractor), request.id);
            }

            return _mapper.Map<AboutContractorDetailsVm>(entity);
        }
    }
}
