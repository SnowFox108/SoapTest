using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest.Entities
{
    public class OriginDestination
    {
        public Departure Departure { get; set; }
        public Arrival Arrival { get; set; }
    }
}
