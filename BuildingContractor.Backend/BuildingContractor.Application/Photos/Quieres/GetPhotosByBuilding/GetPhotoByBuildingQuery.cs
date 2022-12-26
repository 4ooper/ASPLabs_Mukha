using MediatR;

namespace BuildingContractor.Application.Photos.Quieres.GetPhotosByBuilding
{
    public class GetPhotoByBuildingQuery : IRequest<GetPhotoByBuildingListVm>
    {
        public int BuildingId { get; set; }
    }
}
