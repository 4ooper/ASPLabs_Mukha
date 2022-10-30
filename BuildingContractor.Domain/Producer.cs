using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain
{
    public class Producer
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<ConctractorMaterial> conctractorMaterials { get; set; }
    }
}
