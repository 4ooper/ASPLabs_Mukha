using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Photos.Commands.CreatePhoto
{
    public class CreatePhotoCommand : IRequest<Photo>
    {
        public string url { get; set; }
    }
}
