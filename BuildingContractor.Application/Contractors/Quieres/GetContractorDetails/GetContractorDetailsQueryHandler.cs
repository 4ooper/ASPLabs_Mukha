using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorDetails
{
    public class GetContractorDetailsQueryHandler : IRequestHandler<GetContractorDetailsQuery, ContractorDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetContractorDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorDetailsVm> Handle(GetContractorDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.contractors.FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Contractor), request.id);
            }

            return _mapper.Map<ContractorDetailsVm>(entity);
        }
    }
}
