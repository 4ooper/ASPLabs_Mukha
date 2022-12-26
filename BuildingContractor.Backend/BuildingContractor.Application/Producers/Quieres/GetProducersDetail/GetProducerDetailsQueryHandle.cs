using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersDetail
{
    public class GetProducerDetailsQueryHandle : IRequestHandler<GetProducerDetailsQuery, ProducerDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetProducerDetailsQueryHandle(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ProducerDetailsVm> Handle(GetProducerDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.producers.Include(u => u.Materials).FirstOrDefaultAsync(record => record.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Producer), request.Id);
            }

            return _mapper.Map<ProducerDetailsVm>(entity);
        }
    }
}
