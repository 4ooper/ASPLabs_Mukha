using MediatR;

namespace BuildingContractor.Application.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommand : IRequest
    {
        public int Id { get; set; }
    }
}
