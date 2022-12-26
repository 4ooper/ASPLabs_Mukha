using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingFilterList
{
    public class GetBuildingFilterListQueryHandler : IRequestHandler<GetBuildingFilterListQuery, GetBuildingFilterListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        public GetBuildingFilterListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<GetBuildingFilterListVm> Handle(GetBuildingFilterListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Building> records = _dbcontext.buildings.Include(u => u.Contractor).Include(u => u.Customer);
            if (request.ContractorId != null)
            {
                records = records.Where(item => item.ContractorId == request.ContractorId);
            }
            if(request.CustomerId != null)
            {
                records = records.Where(item => item.CustomerId == request.CustomerId);
            }
            if(request.ConclusionDateStart != null)
            {
                records = records.Where(item => item.ConclusionDate >= request.ConclusionDateStart);
            }
            if(request.ConclusionDateEnd != null)
            {
                records = records.Where(item => item.ConclusionDate <= request.ConclusionDateEnd);
            }
            if(request.DeliveryDateStart != null)
            {
                records = records.Where(item => item.DeliveryDate >= request.DeliveryDateStart);
            }
            if(request.DeliveryDateEnd != null)
            {
                records = records.Where(item => item.DeliveryDate >= request.DeliveryDateEnd);
            }
            if(request.ComissioningDateStart != null)
            {
                records = records.Where(item => item.ComissioningDate >= request.ComissioningDateStart);
            }
            if(request.ComissioningDateEnd != null)
            {
                records = records.Where(item => item.ComissioningDate >= request.ComissioningDateEnd);
            }
            if (request.SortValue != null)
            {
                switch (request.SortValue.ToLower())
                {
                    case "id":
                        records = records.OrderBy(x => x.Id);
                        break;
                    case "name":
                        records = records.OrderBy(x => x.Name);
                        break;
                    default:
                        records = records.OrderBy(x => x.Id);
                        break;
                }
                if (request.SortValue.ToLower() == "desc")
                {
                    records = records.Reverse();
                }
            }
            var totalElements = records.Count();
            var maxPage = Math.Ceiling(Decimal.Parse((totalElements / 15.0).ToString()));
            var result = records.Skip(request.Page * 15).Take(15).ProjectTo<GetBuildingFilterLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken).Result;
            return new GetBuildingFilterListVm
            {
                Buildings = result,
                TotalElements = totalElements,
                MaxPage = (int)maxPage
            };
        }
    }
}
