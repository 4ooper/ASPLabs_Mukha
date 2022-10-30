using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain
{
    public class ContractorStock
    {
        public int id { get; set; }
        public int contractorMaterialID { get; set; }
        public ConctractorMaterial conctractorMaterial { get; set; }
        public int count { get; set; }
        public int price { get; set; }

        public List<AboutContractor> aboutContractors { get; set; }
    }
}
