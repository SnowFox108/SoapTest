using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest.Entities
{
    public class Party
    {
        public Sender Sender { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
