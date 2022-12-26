using MediatR;

namespace BuildingContractor.Application.Photos.Commands.DeletePhoto
{
    public class DeletePhotoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
