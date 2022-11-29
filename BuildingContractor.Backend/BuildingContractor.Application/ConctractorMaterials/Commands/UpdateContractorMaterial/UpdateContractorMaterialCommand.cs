using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ConctractorMaterials.Commands.UpdateContractorMaterial
{
    public class UpdateContractorMaterialCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }
        public int ProducerID { get; set; }
    }
}
