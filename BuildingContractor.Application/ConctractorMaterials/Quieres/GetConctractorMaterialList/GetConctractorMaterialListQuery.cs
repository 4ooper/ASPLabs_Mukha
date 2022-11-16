using MediatR;
using Microsoft.AspNetCore.Http;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList
{
    public class GetConctractorMaterialListQuery : IRequest<ConctractorMaterialVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
