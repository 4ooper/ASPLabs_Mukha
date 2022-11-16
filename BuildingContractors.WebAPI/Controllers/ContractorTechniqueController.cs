using BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList;
using BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueDetails;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Application.ContractorTechnique.Commands.CreateContractorTechnique;
using BuildingContractor.Application.ContractorTechnique.Commands.UpdateContractorTechnique;
using BuildingContractor.Application.ContractorTechnique.Commands.DeleteContractorTechnique;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContractorTechniqueController : BaseController
    {
        private readonly IMapper _mapper;

        public ContractorTechniqueController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ContractorTechniqueListVm>> GetAll()
        {
            var query = new GetContractorTechniqueListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ContractorTechniqueDetailsVm>> Get(int id)
        {
            var query = new GetContractorTechniqueDetailsQuery
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
        public async Task<ActionResult<int>> Create([FromForm] CreateContractorTechniqueDto createContractorTechnique)
        {
            var command = _mapper.Map<CreateContractorTechniqueCommand>(createContractorTechnique);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateContractorTechniqueDto updateContractorTechnique)
        {
            var command = _mapper.Map<UpdateContractorTechniqueCommand>(updateContractorTechnique);
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
            var command = new DeleteContractorTechniqueCommand
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
