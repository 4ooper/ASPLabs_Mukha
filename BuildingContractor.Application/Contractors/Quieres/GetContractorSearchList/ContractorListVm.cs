using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList
{
    public class ContractorListVm
    {
        public IList<ContractorLookupDto> contractors { get; set; }
        public string next { get; set; }
        public string back { get; set; }
        public int pagesCount { get; set; }
    }
}
