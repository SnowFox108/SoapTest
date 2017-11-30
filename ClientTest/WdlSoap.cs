using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientTest.MySellingService;

namespace ClientTest
{
    public class WdlSoap
    {
        public WdlSoap()
        {
            var service = new MySellingService.AirShoppingRQ();
            service.Party = new MsgPartiesType();
        }
    }
}
