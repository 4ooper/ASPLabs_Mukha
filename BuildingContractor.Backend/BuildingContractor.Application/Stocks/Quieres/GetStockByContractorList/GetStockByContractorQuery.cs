using MediatR;

namespace BuildingContractor.Application.Stocks.Quieres.GetStockByContractorList
{
    public class GetStockByContractorQuery : IRequest<GetStockByContractorListVm>
    {
        public int ContractorId { get; set; }
    }
}
