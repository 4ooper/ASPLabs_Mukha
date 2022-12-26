using MediatR;
using BuildingContractor.Domain;
using Microsoft.AspNetCore.Http;

namespace BuildingContractor.Application.Photos.Commands.CreatePhoto
{
    public class CreatePhotoCommand : IRequest
    {
        public IFormFile Photo { get; set; }
        public int BuildingId { get; set; }
    }
}
