using MediatR;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorDetails
{
    public class GetContractorDetailsQuery : IRequest<ContractorDetailsVm>
    {
        public int Id { get; set; }
    }
}
