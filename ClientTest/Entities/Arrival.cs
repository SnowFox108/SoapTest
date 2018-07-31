using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientTest.Entities.Receiving;

namespace ClientTest.Entities
{
    public class Arrival
    {
        public string AirportCode { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int ChangeOfDay { get; set; }
        public string AirportName { get; set; }
        public Terminal Terminal { get; set; }
    }
}
