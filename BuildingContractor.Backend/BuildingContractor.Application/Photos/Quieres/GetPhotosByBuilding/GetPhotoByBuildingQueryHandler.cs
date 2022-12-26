using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Photos.Quieres.GetPhotosByBuilding
{
    public class GetPhotoByBuildingQueryHandler : IRequestHandler<GetPhotoByBuildingQuery, GetPhotoByBuildingListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetPhotoByBuildingQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<GetPhotoByBuildingListVm> Handle(GetPhotoByBuildingQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.photos.Where(item => item.BuildingId == request.BuildingId).ToListAsync(cancellationToken);
            IList<GetPhotoByBuildingLookupDto> photos = new List<GetPhotoByBuildingLookupDto>();
            foreach(var photo in records)
            {
                byte[] b = File.ReadAllBytes(photo.PhotoURL);
                string base64String = Convert.ToBase64String(b, 0, b.Length);
                photos.Add(new GetPhotoByBuildingLookupDto
                {
                    Id = photo.Id,
                    Photo = "data:image/jpeg;base64," + base64String
                });
            }
            return new GetPhotoByBuildingListVm
            {
                Photos = photos
            };
        }
    }
}
