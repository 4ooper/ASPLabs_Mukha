using MediatR;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockDetails
{
    public class GetContractorStockDetailsQuery : IRequest<ContractorStockDetailsVm>
    {
        public int id { get; set; }
    }
}
