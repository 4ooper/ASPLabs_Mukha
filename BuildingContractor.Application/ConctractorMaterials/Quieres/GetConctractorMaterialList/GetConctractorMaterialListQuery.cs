using MediatR;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList
{
    public class GetConctractorMaterialListQuery : IRequest<ConctractorMaterialVm>
    {
        public string cacheKey { get; set; } = "firstsearch";
    }
}
