using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain
{
    public class License
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime validaty { get; set; }

        public List<listOfWork> listOfWorks { get; set; }
    }
}
