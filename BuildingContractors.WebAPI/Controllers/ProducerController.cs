using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Producers.Quieres.GetProducersList;
using BuildingContractor.Application.Producers.Quieres.GetProducersDetail;
using BuildingContractor.Application.Producers.Commands.CreateProducer;
using BuildingContractor.Application.Producers.Commands.UpdateProducer;
using BuildingContractor.Application.Producers.Commands.DeleteProducer;


namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProducerController : BaseController
    {
        private readonly IMapper _mapper;

        public ProducerController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ProducerListVm>> GetAll()
        {
            var query = new GetProducerListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ProducerListVm>> Get(int id)
        {
            var query = new GetProducerDetailsQuery
            {
                id = id
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateProducerDto createProducerDto)
        {
            var command = _mapper.Map<CreateProducerCommand>(createProducerDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProducerDto updateProducerDto)
        {
            var command = _mapper.Map<UpdateProducerCommand>(updateProducerDto);
            try
            {
                await Mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProducerCommand
            {
                id = id,
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
