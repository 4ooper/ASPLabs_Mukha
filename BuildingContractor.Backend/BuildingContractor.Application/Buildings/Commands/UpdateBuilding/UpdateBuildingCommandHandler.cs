using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand, Building>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateBuildingCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Building> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.buildings.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.Id != request.Id)
            {
                throw new NotFoundException(nameof(Building), request.Id);
            }

            entity.Result.Name = request.Name;
            entity.Result.CustomerId = request.CustomerId;
            entity.Result.ContractorId = request.ContractorId;
            entity.Result.ConclusionDate = request.ConclusionDate;
            entity.Result.ComissioningDate = request.ComissioningDate;
            entity.Result.DeliveryDate = request.DeliveryDate;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity.Result;
        }
    }
}
