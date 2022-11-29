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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContractorTechniqueController : BaseController
    {
        private readonly IMapper _mapper;

        public ContractorTechniqueController(IMapper mapper) => _mapper = mapper;


        /// <summary>
        /// Get the list of ContractorTechniques
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractorTechnique
        /// </remarks>
        /// <param name="page">Number of page</param>
        /// <returns>Return ContractorTechniqueListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("[action]/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ContractorTechniqueListVm>> GetAll([FromQuery] int page)
        {
            var query = new GetContractorTechniqueListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Gets the contractorTechnique by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractorTechnique/0
        /// </remarks>
        /// <param name="id">ContractorTechnique Id</param>
        /// <returns>Return ContractorTechniqueDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpGet("{id}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Create ContractorTechnique
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /ContractorTechnique
        /// {
        ///     name: "Test",
        ///     buyDate: "2020-10-12",
        ///     validaty: "2025-10-12"
        /// }
        /// </remarks>
        /// <param name="createContractorTechnique">CreateContractorTechniqueDto object</param>
        /// <returns>Return ContractorTechnique</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create([FromForm] CreateContractorTechniqueDto createContractorTechnique)
        {
            var command = _mapper.Map<CreateContractorTechniqueCommand>(createContractorTechnique);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        /// <summary>
        /// Update ContractorTechnique
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /ContractorTechnique
        /// {
        ///     id: 0,
        ///     name: "Test2"
        /// }
        /// </remarks>
        /// <param name="updateContractorTechnique">UpdateContractorTechniqueDto object</param>
        /// <returns>Return NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Delete ContractorTechnique
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /ContractorTechnique/0
        /// </remarks>
        /// <param name="id">ContractorTechnique Id</param>
        /// <returns>Return NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
