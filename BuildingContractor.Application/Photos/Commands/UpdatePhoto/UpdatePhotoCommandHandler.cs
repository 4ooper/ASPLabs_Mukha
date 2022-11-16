using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Photos.Commands.UpdatePhoto
{
    public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, Photo>
    {

        private readonly INotesDbContext _dbcontext;

        public UpdatePhotoCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Photo> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.photos.FirstOrDefaultAsync(photo => photo.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Photo), request.id);
            }

            entity.Result.url =  request.url;

            var newPhoto = await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity.Result;
        }
    }
}
