using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Producers.Quieres.GetProducersList;
using BuildingContractor.Application.Producers.Quieres.GetProducersDetail;
using BuildingContractor.Application.Producers.Commands.CreateProducer;
using BuildingContractor.Application.Producers.Commands.UpdateProducer;
using BuildingContractor.Application.Producers.Commands.DeleteProducer;
using BuildingContractor.Application.Producers.Quieres.GetProducersSearchList;
using BuildingContractor.Application.Producers.Quieres.GetProudersFilterList;


namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProducerController : BaseController
    {
        private readonly IMapper _mapper;
        public ProducerController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ProducerListVm>> GetAll([FromQuery] int page)
        {
            var canAccept = CanAccept((User)HttpContext.Items["User"]) == false;
            if (canAccept == false)
            {
                return Unauthorized();
            }
            var query = new GetProducerListQuery { Page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query) ;
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<GetProducersFilterListVm>> Filter([FromQuery] int page, string prop, string value)
        {
            var query = new GetProducersFilterListQuery
            {
                Page = page >= 0 ? page : 0,
                SortProp = prop,
                SortValue = value
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<ProducerSearchListVm>> Search([FromQuery] int page, [FromQuery] string searchText)
        {
            var query = new GetProducerSearchListQuery { Page = page >= 0 ? page : 0, SearchText = searchText };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
            
        [HttpGet("{id}/")]
        public async Task<ActionResult<ProducerDetailsVm>> Get(int id)
        {
            var query = new GetProducerDetailsQuery
            {
                Id = id
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
        public async Task<ActionResult<int>> Create([FromBody] CreateProducerDto createProducerDto)
        {
            var command = _mapper.Map<CreateProducerCommand>(createProducerDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }
            
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProducerDto updateProducerDto)
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

        private bool CanAccept(User user)
        {
            return user == null;
        }
    }
}
