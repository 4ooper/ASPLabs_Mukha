using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommand : IRequest<Material>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public int ProducerId { get; set; }
    }
}
