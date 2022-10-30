using MediatR;


namespace BuildingContractor.Application.Contractors.Quieres.GetContractorDetails
{
    public class GetContractorDetailsQuery : IRequest<ContractorDetailsVm>
    {
        public int id { get; set; }
    }
}
