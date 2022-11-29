using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorStocks.Commands.UpdateContractorStock
{
    public class UpdateContractorStockCommand : IRequest
    {
        public int id { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public ConctractorMaterial contractorMaterial { get; set; }
    }
}
