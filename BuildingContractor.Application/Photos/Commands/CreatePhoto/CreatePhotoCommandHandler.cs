using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Photos.Commands.CreatePhoto
{
    public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, Photo>
    {
        private readonly INotesDbContext _dbcontext;

        public CreatePhotoCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Photo> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = new Photo
            {
                url = request.url
            };

            var newPhoto = await _dbcontext.photos.AddAsync(photo, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return newPhoto.Entity;
        }
    }
}
