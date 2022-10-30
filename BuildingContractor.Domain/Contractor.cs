using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain
{
    public class Contractor
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<AboutContractor> aboutContractors { get; set; }
        
    }
}
