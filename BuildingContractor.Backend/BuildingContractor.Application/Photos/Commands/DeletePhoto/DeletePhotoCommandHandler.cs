using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Photos.Commands.DeletePhoto
{
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeletePhotoCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.photos.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != entity.Id)
            {
                throw new NotFoundException(nameof(Photo), request.Id);
            }

            if (File.Exists(entity.PhotoURL))
            {
                File.Delete(entity.PhotoURL);
                _dbcontext.photos.Remove(entity);
                await _dbcontext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception();
            };

            return Unit.Value;
        }
    }
}
