using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.Buildings.Quieres.GetBuildingFilterList
{
    public class GetBuildingFilterListVm
    {
        public IList<GetBuildingFilterLookupDto> Buildings { get; set; }
        public int TotalElements { get; set; }
        public int MaxPage { get; set; }
    }
}
