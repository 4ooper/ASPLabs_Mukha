using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorStocks.Commands.CreateContractorStock
{
    public class CreateContractorStockCommand : IRequest<ContractorStock>
    {
        public int count { get; set; }
        public int price { get; set; }
        public ConctractorMaterial conctractorMaterial { get; set; }
    }
}
