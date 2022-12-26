using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteCustomerCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.customers.FindAsync(new object[] { request.Id }, cancellationToken);

            if(entity == null || entity.Id != entity.Id)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _dbcontext.customers.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
