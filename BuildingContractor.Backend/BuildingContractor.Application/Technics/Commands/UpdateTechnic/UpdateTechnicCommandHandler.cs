using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Technics.Commands.UpdateTechnic
{
    public class UpdateTechnicCommandHandler : IRequestHandler<UpdateTechnicCommand, Technic>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateTechnicCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Technic> Handle(UpdateTechnicCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.technics.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.Id != request.Id)
            {
                throw new NotFoundException(nameof(Technic), request.Id);
            }

            entity.Result.Name = request.Name;
            entity.Result.ContractorId = request.ContractorId;
            entity.Result.CreationDate = request.CreationDate;
            entity.Result.Valid = request.Valid;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity.Result;
        }
    }
}
