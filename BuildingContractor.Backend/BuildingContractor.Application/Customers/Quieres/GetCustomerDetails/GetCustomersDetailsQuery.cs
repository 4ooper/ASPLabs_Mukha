﻿using MediatR;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerDetails
{
    public class GetCustomersDetailsQuery : IRequest<CustomerDetailsVm>
    {
        public int Id { get; set; }
    }
}
