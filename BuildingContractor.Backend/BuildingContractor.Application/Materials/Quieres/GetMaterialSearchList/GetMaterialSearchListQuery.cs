using MediatR;

namespace BuildingContractor.Application.Materials.Quieres.GetMaterialSearchList
{
    public class GetMaterialSearchListQuery : IRequest<MaterialSearchListVm>
    {
        public string SearchText { get; set; }
    }
}
