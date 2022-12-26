using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, Building>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateBuildingCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Building> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var record = new Building
            {
                Name = request.Name,
                CustomerId = request.CustomerId,
                ContractorId = request.ContractorId,
                ConclusionDate = request.ConclusionDate,
                ComissioningDate = request.ComissioningDate,
                DeliveryDate = request.DeliveryDate
            };

            await _dbcontext.buildings.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
