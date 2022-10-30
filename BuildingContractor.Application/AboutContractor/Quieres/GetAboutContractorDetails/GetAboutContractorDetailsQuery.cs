using MediatR;

namespace BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorDetails
{
    public class GetAboutContractorDetailsQuery : IRequest<AboutContractorDetailsVm>
    {
        public int id { get; set; }
    }
}
