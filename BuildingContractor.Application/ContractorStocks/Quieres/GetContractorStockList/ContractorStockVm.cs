using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockList
{
    public class ContractorStockVm
    {
        public IList<ContractorStockLookupDto> contractorStock { get; set; }
    }
}
