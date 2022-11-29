using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList
{
    public class ContractorTechniqueListVm
    {
        public IList<ContractorTechniqueLookupDto> contractorTechniques { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
