using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain.JWT
{
    public class Header
    {
        public string alg { get; set; }
        public string typ { get; set; }
    }
}
