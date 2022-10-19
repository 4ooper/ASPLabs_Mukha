using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ConctractorMaterials.Commands.CreateContractorMaterial
{
    public class CreateContractorMaterialCommand : IRequest<ConctractorMaterial>
    {
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }
        public Producer producer { get; set; }
    }
}
