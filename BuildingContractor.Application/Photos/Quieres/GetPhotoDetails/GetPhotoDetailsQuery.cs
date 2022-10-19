using MediatR;


namespace BuildingContractor.Application.Photos.Quieres.GetPhotoDetails
{
    public class GetPhotoDetailsQuery : IRequest<PhotoDetailsVm>
    {
        public int id { get; set; }
    }
}
