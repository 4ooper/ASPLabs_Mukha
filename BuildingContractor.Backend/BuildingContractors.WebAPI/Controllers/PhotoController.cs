using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Application.Photos.Commands.CreatePhoto;
using BuildingContractor.Application.Photos.Commands.DeletePhoto;
using BuildingContractor.Application.Photos.Quieres.GetPhotosByBuilding;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : BaseController
    {
        private readonly IMapper _mapper;

        public PhotoController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{id}/")]
        public async Task<ActionResult<GetPhotoByBuildingListVm>> GetByBuilding(int id)
        {
            var query = new GetPhotoByBuildingQuery
            {
                BuildingId = id
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
        public async Task<ActionResult<int>> Create([FromForm] CreatePhotoDto createPhotoDto)
        {
            var command = _mapper.Map<CreatePhotoCommand>(createPhotoDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePhotoCommand
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
