using MediatR;

namespace BuildingContractor.Application.ContractorStocks.Commands.DeleteContractorStock
{
    public class DeleteContractorStockCommand : IRequest
    {
        public int id { get; set; }
    }
}
