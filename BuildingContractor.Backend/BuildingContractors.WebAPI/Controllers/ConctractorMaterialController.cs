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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ConctractorMaterialController : BaseController
    {
        private readonly IMapper _mapper;

        public ConctractorMaterialController(IMapper mapper) => _mapper = mapper;


        /// <summary>
        /// Get the list of ContractorMaterials
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractorMaterial
        /// </remarks>
        /// <param name="page">Number of page</param>
        /// <returns>Return ConctractorMaterialVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("[action]/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ConctractorMaterialVm>> GetAll([FromQuery] int page)
        {
            var query = new GetConctractorMaterialListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the contractor material by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractorMaterial/0
        /// </remarks>
        /// <param name="id">Contractor Material Id</param>
        /// <returns>Return ContractorMaterialDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpGet("{id}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Create Contractor Material
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /contractorMaterial
        /// {
        ///     name: "Test"
        /// }
        /// </remarks>
        /// <param name="createContractorMaterial">CreateContractorMaterialDto object</param>
        /// <returns>Return Contractor Material</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateContractorMaterialDto createContractorMaterial)
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

        /// <summary>
        /// Update Contractor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /contractor
        /// {
        ///     id: 0,
        ///     name: "Test2"
        /// }
        /// </remarks>
        /// <param name="updateContractorMaterial">UpdateContractorDto object</param>
        /// <returns>Return NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractorMaterialDto updateContractorMaterial)
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

        /// <summary>
        /// Delete Contractor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /contractor/0
        /// </remarks>
        /// <param name="id">Contractor Id</param>
        /// <returns>Return NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
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
