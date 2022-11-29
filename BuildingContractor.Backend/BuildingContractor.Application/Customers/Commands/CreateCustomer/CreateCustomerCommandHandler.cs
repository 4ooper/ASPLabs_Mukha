using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly INotesDbContext _dbcontext;

        public CreateCustomerCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                name = request.name,
                surname = request.surname
            };

            await _dbcontext.customers.AddAsync(customer, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}
