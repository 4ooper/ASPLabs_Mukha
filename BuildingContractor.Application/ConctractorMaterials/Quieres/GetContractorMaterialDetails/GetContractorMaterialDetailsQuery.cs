using MediatR;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialDetails
{
    public class GetContractorMaterialDetailsQuery : IRequest<ContractorMaterialDetailsVm>
    {
        public int id { get; set; }
    }
}
