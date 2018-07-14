using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest.Entities
{
    public class AirShoppingRQ
    {
        public Document Document { get; set; }
        public Party Party { get; set; }
        public List<Traveler> Travelers { get; set; }
    }
}
