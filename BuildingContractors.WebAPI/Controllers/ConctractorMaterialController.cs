using BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList;
using BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialDetails;
using BuildingContractor.Application.ConctractorMaterials.Commands.CreateContractorMaterial;
using BuildingContractor.Application.ConctractorMaterials.Commands.DeleteContractorMaterial;
using BuildingContractor.Application.ConctractorMaterials.Commands.UpdateContractorMaterial;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ConctractorMaterialController : BaseController
    {
        private readonly IMapper _mapper;

        public ConctractorMaterialController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ConctractorMaterialVm>> GetAll()
        {
            var query = new GetConctractorMaterialListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ContractorMaterialDetailsVm>> Get(int id)
        {
            var query = new GetContractorMaterialDetailsQuery
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
        public async Task<ActionResult<int>> Create([FromForm] CreateContractorMaterialDto createContractorMaterial)
        {
            try
            {
                var command = _mapper.Map<CreateContractorMaterialCommand>(createContractorMaterial);
                var noteId = await Mediator.Send(command);
                return Ok(noteId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateContractorMaterialDto updateContractorMaterial)
        {
            var command = _mapper.Map<UpdateContractorMaterialCommand>(updateContractorMaterial);
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
            var command = new DeleteContractorMaterialCommand
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
