using MediatR;
using BuildingContractor.Domain;


namespace BuildingContractor.Application.Photos.Commands.UpdatePhoto
{
    public class UpdatePhotoCommand : IRequest<Photo>
    {
        public int id { get; set; }
        public string url { get; set; }
    }
}
