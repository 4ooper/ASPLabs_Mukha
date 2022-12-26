using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorList
{
    public class ContractorListVm
    {
        public IList<ContractorLookupDto> Contractors { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
