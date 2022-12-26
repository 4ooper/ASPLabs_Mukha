using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Technics.Commands.CreateTechnic;
using BuildingContractor.Application.Technics.Commands.UpdateTechnic;
using BuildingContractor.Application.Technics.Commands.DeleteTechnic;
using BuildingContractor.Application.Technics.Quieres.GetTechnicByContractorList;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TechnicController : BaseController
    {
        private readonly IMapper _mapper;
        public TechnicController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<GetTechnicByContractorListVm>> GetAllByContractor([FromQuery] int contractor)
        {
            var query = new GetTechnicByContractorQuery { ContractorId = contractor };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateTechnicDto createStockDto)
        {
            var command = _mapper.Map<CreateTechnicCommand>(createStockDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult<Technic>> Update([FromBody] UpdateTechnicDto updateStockDto)
        {
            var command = _mapper.Map<UpdateTechnicCommand>(updateStockDto);
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
            var command = new DeleteTechnicCommand
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
