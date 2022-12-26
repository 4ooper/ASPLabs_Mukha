using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommand : IRequest<Material>
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public int ProducerId { get; set; }
    }
}
