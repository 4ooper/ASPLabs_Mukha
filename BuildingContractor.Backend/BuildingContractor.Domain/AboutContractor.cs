using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain
{
    public class AboutContractor
    {
        public int id { get; set; }
        public int contractorID { get; set; }
        public Contractor contractor { get; set; }
        public int contractorStockID { get; set; }
        public ContractorStock contractorStock { get; set; }
        public int contractorTechniquesID { get; set; } 
        public ContractorTechniques contractorTechnique { get; set; }
    }
}
