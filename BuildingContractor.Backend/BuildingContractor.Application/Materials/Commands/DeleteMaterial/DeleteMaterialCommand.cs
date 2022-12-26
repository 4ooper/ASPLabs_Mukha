using MediatR;

namespace BuildingContractor.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommand : IRequest
    {
        public int Id { get; set; }
    }
}
