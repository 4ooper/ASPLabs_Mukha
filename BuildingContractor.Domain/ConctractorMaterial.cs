using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BuildingContractor.Domain
{
    public class ConctractorMaterial
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }
        public int producerID { get; set; }
        public Producer? producer { get; set; }

        public List<ContractorStock> contractorStocks { get; set; }
    }
}
