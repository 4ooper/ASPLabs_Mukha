using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Stocks.Commands.UpdateStock
{
    public class UpdateStockCommand : IRequest<Stock>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int MaterialId { get; set; }
        public int ContractorId { get; set; }


    }
}
