using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Stocks.Commands.CreateStock
{
    public class CreateStockCommand : IRequest<Stock>
    {
        public int Count { get; set; }
        public int MaterialId { get; set; }
        public int ContractorId { get; set; }
    }
}
