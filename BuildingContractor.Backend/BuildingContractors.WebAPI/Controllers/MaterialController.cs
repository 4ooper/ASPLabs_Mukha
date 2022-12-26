using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Materials.Commands.CreateMaterial;
using BuildingContractor.Application.Materials.Commands.UpdateMaterial;
using BuildingContractor.Application.Materials.Commands.DeleteMaterial;
using BuildingContractor.Application.Materials.Quieres.GetMaterialDetails;
using BuildingContractor.Application.Materials.Quieres.GetMaterialSearchList;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MaterialController : BaseController
    {
        private readonly IMapper _mapper;
        public MaterialController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{id}/")]
        public async Task<ActionResult<MaterialDetailsVm>> Get(int id)
        {
            var query = new GetMaterialDetailsQuery
            {
                Id = id
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

        [HttpGet("[action]/")]
        public async Task<ActionResult<MaterialSearchListVm>> Search([FromQuery] string searchText)
        {
            var query = new GetMaterialSearchListQuery { SearchText = searchText };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateMaterialDto createMaterialDto)
        {
            var command = _mapper.Map<CreateMaterialCommand>(createMaterialDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult<Material>> Update([FromBody] UpdateMaterialDto updateMaterialDto)
        {
            var command = _mapper.Map<UpdateMaterialCommand>(updateMaterialDto);
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
            var command = new DeleteMaterialCommand
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
