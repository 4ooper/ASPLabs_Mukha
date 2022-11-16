using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingContractor.Domain.JWTModels
{
    public class Payload
    {
        public int id { get; set; }
        public int exp { get; set; }
    }
}
