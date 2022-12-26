using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BuildingContractor.Application.Photos.Commands.CreatePhoto
{
    public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public CreatePhotoCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;

        public async Task<Unit> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
        {
            IFormFile file = request.Photo;
            string fileName = $"{DateTime.Now.ToShortDateString()}_{DateTime.Now.Millisecond}_{DateTime.Now.Minute}_{file.FileName}";
            int len = fileName.Length;
            var uploadPath = @"../uploads";
            string fullPath = $"{uploadPath}/{fileName}";

            Photo photo;
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                photo = new Photo
                {
                    PhotoURL = fullPath,
                    BuildingId = request.BuildingId
                };
            }

            await _dbcontext.photos.AddAsync(photo, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
