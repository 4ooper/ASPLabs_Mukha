using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Application.Photos.Commands.CreatePhoto;
using BuildingContractor.Application.Photos.Commands.DeletePhoto;
using BuildingContractor.Application.Photos.Commands.UpdatePhoto;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Photos.Quieres.GetPhotoDetails;
using BuildingContractor.Application.Photos.Quieres.GetPhotoList;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : BaseController
    {
        private readonly IMapper _mapper;

        public PhotoController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<PhotoListVm>> GetAll()
        {
            var query = new GetPhotoListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<PhotoDetailsVm>> Get(int id)
        {
            var query = new GetPhotoDetailsQuery
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

        [HttpPost]
        public async Task<ActionResult<Photo>> Create([FromForm] CreatePhotoDto createPhotoDto)
        {
            var command = _mapper.Map<CreatePhotoCommand>(createPhotoDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult<Photo>> Update([FromForm] UpdatePhotoDto updatePhotoDto)
        {
            var command = _mapper.Map<UpdatePhotoCommand>(updatePhotoDto);
            try
            {
                var photo = await Mediator.Send(command);
                return photo;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePhotoCommand
            {
                id = id,
            };
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
    }
}
