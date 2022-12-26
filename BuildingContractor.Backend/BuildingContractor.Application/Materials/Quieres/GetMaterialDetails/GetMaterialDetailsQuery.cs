using MediatR;

namespace BuildingContractor.Application.Materials.Quieres.GetMaterialDetails
{
    public class GetMaterialDetailsQuery : IRequest<MaterialDetailsVm>
    {
        public int Id { get; set; }
    }
}
