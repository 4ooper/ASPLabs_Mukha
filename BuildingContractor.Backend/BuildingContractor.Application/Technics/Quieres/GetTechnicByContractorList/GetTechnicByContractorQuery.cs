using MediatR;

namespace BuildingContractor.Application.Technics.Quieres.GetTechnicByContractorList
{
    public class GetTechnicByContractorQuery : IRequest<GetTechnicByContractorListVm>
    {
        public int ContractorId { get; set; }
    }
}
