using BuildingContractor.Application.Contractors.Quieres.GetContractorList;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList
{
    public class ContractorSearchListVm
    {
        public IList<ContractorLookupDto> Contractors { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
