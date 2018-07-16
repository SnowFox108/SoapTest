using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest.Entities
{
    public class Preference
    {
        public FarePreferences FarePreferences { get; set; }
        public CabinPreferences CabinPreferences { get; set; }
    }
}
