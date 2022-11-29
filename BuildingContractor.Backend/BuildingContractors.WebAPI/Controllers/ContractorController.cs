using BuildingContractor.Application.Contractors.Quieres.GetContractorList;
using BuildingContractor.Application.Contractors.Quieres.GetContractorDetails;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Application.Contractors.Commands.CreateContractor;
using BuildingContractor.Application.Contractors.Commands.UpdateContractor;
using BuildingContractor.Application.Contractors.Commands.DeleteContractor;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContractorController : BaseController
    {
        private readonly IMapper _mapper;

        public ContractorController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the list of Contractors
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractor
        /// </remarks>
        /// <param name="page">Number of page</param>
        /// <returns>Return ContractorListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("[action]/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ContractorListVm>> GetAll([FromQuery] int page)
        {
            var query = new GetContractorListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the contractor by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractor/0
        /// </remarks>
        /// <param name="id">Contractor Id</param>
        /// <returns>Return ContractorDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("{id}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ContractorDetailsVm>> Get(int id)
        {
            var query = new GetContractorDetailsQuery
            {
                id = id
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

        /// <summary>
        /// Create Contractor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /contractor
        /// {
        ///     name: "Test"
        /// }
        /// </remarks>
        /// <param name="createContractorDto">CreateContractorDto object</param>
        /// <returns>Return Contractor</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]   
        public async Task<ActionResult<int>> Create([FromBody] CreateContractorDto createContractorDto)
        {
            var command = _mapper.Map<CreateContractorCommand>(createContractorDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
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
        /// <param name="updateContractorDto">UpdateContractorDto object</param>
        /// <returns>Return NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateContractorDto updateContractorDto)
        {
            var command = _mapper.Map<UpdateContractorCommand>(updateContractorDto);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContractorCommand
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
