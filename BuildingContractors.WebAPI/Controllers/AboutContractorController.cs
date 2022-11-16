using BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorList;
using BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorDetails;
using BuildingContractor.Application.AboutContractor.Commands.CreateAboutContractor;
using BuildingContractor.Application.AboutContractor.Commands.UpdateAboutContractor;
using BuildingContractor.Application.AboutContractor.Commands.DeleteAboutContractor;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AboutContractorController : BaseController
    {
        private readonly IMapper _mapper;

        public AboutContractorController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<AboutContractorVm>> GetAll()
        {
            var query = new GetAboutContractorListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<AboutContractorDetailsVm>> Get(int id)
        {
            var query = new GetAboutContractorDetailsQuery
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
        public async Task<ActionResult<int>> Create([FromForm] CreateAboutContractorDto createAboutContractor)
        {
            try
            {
                var command = _mapper.Map<CreateAboutContractorCommand>(createAboutContractor);
                var noteId = await Mediator.Send(command);
                return Ok(noteId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateAboutContractorDto updateAboutContractor)
        {
            var command = _mapper.Map<UpdateAboutContractorCommand>(updateAboutContractor);
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAboutContractorCommand
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
