﻿using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommandHandler : IRequestHandler<DeleteContractorCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteContractorCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteContractorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.contractors.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != entity.Id)
            {
                throw new NotFoundException(nameof(Contractor), request.Id);
            }

            _dbcontext.contractors.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
