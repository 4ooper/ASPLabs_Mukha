using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorList
{
    public class ContractorListVm
    {
        public IList<ContractorLookupDto> contractors { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
