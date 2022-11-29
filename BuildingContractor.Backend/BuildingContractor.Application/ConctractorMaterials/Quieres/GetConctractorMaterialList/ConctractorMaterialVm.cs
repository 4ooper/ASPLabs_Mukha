using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList
{
    public class ConctractorMaterialVm
    {
        public IList<ConctractorMaterialLookupDto> conctractorMaterials { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
