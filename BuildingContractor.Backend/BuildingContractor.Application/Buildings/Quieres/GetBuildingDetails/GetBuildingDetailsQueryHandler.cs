using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingDetails
{
    public class GetBuildingDetailsQueryHandler : IRequestHandler<GetBuildingDetailsQuery, GetBuildingDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBuildingDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<GetBuildingDetailsVm> Handle(GetBuildingDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.buildings.Include(u => u.Contractor).Include(u => u.Customer).FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Building), request.Id);
            }

            return _mapper.Map<GetBuildingDetailsVm>(entity);
        }
    }
}
