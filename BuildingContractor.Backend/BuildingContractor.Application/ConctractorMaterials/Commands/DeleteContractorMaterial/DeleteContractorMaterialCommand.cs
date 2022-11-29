using MediatR;


namespace BuildingContractor.Application.ConctractorMaterials.Commands.DeleteContractorMaterial
{
    public class DeleteContractorMaterialCommand : IRequest
    {
        public int id { get; set; }
    }
}
