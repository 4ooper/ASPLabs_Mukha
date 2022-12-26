using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Stocks.Commands.CreateStock;
using BuildingContractor.Application.Stocks.Commands.UpdateStock;
using BuildingContractor.Application.Stocks.Commands.DeleteStock;
using BuildingContractor.Application.Stocks.Quieres.GetStockByContractorList;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StockController : BaseController
    {
        private readonly IMapper _mapper;
        public StockController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<GetStockByContractorListVm>> GetAllByContractor([FromQuery] int contractor)
        {
            var query = new GetStockByContractorQuery { ContractorId = contractor };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateStockDto createStockDto)
        {
            var command = _mapper.Map<CreateStockCommand>(createStockDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult<Material>> Update([FromBody] UpdateStockDto updateStockDto)
        {
            var command = _mapper.Map<UpdateStockCommand>(updateStockDto);
            try
            {
                var vm = await Mediator.Send(command);
                return Ok(vm);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteStockCommand
            {
                Id = id,
            };
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
