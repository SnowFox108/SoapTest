using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientTest.Entities;
using ClientTest.MySellingService;

namespace ClientTest
{
    public class WdlSoap
    {
        public WdlSoap()
        {

            var airShopping = new MySellingService.AirShoppingRQ();

            airShopping.Party = new MsgPartiesType()
            {
                Sender = new MsgPartiesTypeSender()
                {
                    Item = new TravelAgencySenderType()
                    {
                        Name = "Travel Centre Clapham",
                        IATA_Number = "91210092",
                        AgencyID = new AgencyID_Type() { Owner = "Travel Centre Clapham Limited"}
                    }
                }
            };



            //Console.WriteLine(response);
        }
    }
}
