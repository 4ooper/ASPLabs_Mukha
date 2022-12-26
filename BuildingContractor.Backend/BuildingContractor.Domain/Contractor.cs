using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain
{
    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Building> Buildings { get; set; }
        public IList<Technic> Technics { get; set; }
        public IList<Stock> Stock { get; set; }
    }
}
