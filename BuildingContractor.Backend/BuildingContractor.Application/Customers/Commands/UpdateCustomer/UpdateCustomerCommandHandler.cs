using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateCustomerCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.customers.FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.Id != request.Id)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            entity.Result.Name = request.Name;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
