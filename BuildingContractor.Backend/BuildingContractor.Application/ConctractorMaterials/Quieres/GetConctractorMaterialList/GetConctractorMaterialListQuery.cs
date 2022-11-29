using MediatR;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList
{
    public class GetConctractorMaterialListQuery : IRequest<ConctractorMaterialVm>
    {
        public int page { get; set; }
    }
}
