using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.ProvidedWorks.Commands.CreateProvidedWork;
using BuildingContractor.Application.ProvidedWorks.Commands.UpdateProvidedWork;
using BuildingContractor.Application.ProvidedWorks.Commands.DeleteProvidedWork;
using BuildingContractor.Application.ProvidedWorks.Queieres.GetProvidedWorkByBuilding;


namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProvidedWorkController : BaseController
    {
        private readonly IMapper _mapper;
        public ProvidedWorkController(IMapper mapper) => _mapper = mapper;

        [HttpGet("building/{id}/")]
        public async Task<ActionResult<GetProvidedWorkByBuildingListVm>> Get(int id)
        {
            var query = new GetProvidedWorkByBuildingQuery
            {
                BuildingId = id
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProvidedWorkDto createProvidedWorkDto)
        {
            var command = _mapper.Map<CreateProvidedWorkCommand>(createProvidedWorkDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult<ProvidedWork>> Update([FromBody] UpdateProvidedWorkDto updateProvidedWorkDto)
        {
            var command = _mapper.Map<UpdateProvidedWorkCommand>(updateProvidedWorkDto);
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
            var command = new DeleteProvidedWorkCommand
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
