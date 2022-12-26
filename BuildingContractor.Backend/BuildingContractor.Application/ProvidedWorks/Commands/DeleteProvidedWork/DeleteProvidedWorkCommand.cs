using MediatR;

namespace BuildingContractor.Application.ProvidedWorks.Commands.DeleteProvidedWork
{
    public class DeleteProvidedWorkCommand : IRequest
    {
        public int Id { get; set; }
    }
}
