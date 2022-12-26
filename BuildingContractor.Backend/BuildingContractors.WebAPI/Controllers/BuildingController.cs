using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Buildings.Commands.CreateBuilding;
using BuildingContractor.Application.Buildings.Commands.UpdateBuilding;
using BuildingContractor.Application.Buildings.Commands.DeleteBuilding;
using BuildingContractor.Application.Buildings.Quieres.GetBuildingList;
using BuildingContractor.Application.Buildings.Quieres.GetBuildingDetails;
using BuildingContractor.Application.Buildings.Quieres.GetBuildingSearchList;
using BuildingContractor.Application.Buildings.Quieres.GetBuildingFilterList;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BuildingController : BaseController
    {
        private readonly IMapper _mapper;
        public BuildingController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<GetBuildingListVm>> GetAll([FromQuery] int page)
        {
            var query = new GetBuildingListQuery { Page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<GetBuildingFilterListVm>> Filter([FromQuery] BuildingFilterDto buildingFilterDto)
        {
            var query = new GetBuildingFilterListQuery
            {
                Page = buildingFilterDto.Page >= 0 ? buildingFilterDto.Page : 0,
                SortProp = buildingFilterDto.SortProp,
                SortValue = buildingFilterDto.SortValue,
                ContractorId = buildingFilterDto.ContractorId,
                CustomerId = buildingFilterDto.CustomerId,
                ConclusionDateStart = buildingFilterDto.ConclusionDateStart,
                ConclusionDateEnd = buildingFilterDto.ConclusionDateEnd,
                DeliveryDateStart = buildingFilterDto.DeliveryDateStart,
                DeliveryDateEnd = buildingFilterDto.DeliveryDateEnd,
                ComissioningDateStart = buildingFilterDto.ComissioningDateStart,
                ComissioningDateEnd = buildingFilterDto.ComissioningDateEnd,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<GetBuildingSearchListVm>> Search([FromQuery] string searchText, [FromQuery] int page)
        {
            var query = new GetBuildingSearchListQuery { SearchText = searchText, Page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<GetBuildingDetailsVm>> Get(int id)
        {
            var query = new GetBuildingDetailsQuery
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

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateBuildingDto createBuildingDto)
        {
            var command = _mapper.Map<CreateBuildingCommand>(createBuildingDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBuildingDto updateBuildingDto)
        {
            var command = _mapper.Map<UpdateBuildingCommand>(updateBuildingDto);
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
            var command = new DeleteBuildingCommand
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
