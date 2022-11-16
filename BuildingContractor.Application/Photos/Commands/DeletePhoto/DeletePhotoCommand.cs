using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Photos.Commands.DeletePhoto
{
    public class DeletePhotoCommand : IRequest
    {
        public int id { get; set; }
    }
}
