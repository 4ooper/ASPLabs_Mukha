using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersList
{
    public class ProducerListVm
    {
        public IList<ProducerLookupDto> producers { get; set; }
    }
}
