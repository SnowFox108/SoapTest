using System.Collections.Generic;

namespace ClientTest.Entities
{
    public class TravelAgencySender
    {
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
        public string IATA_Number { get; set; }
        public string AgencyID { get; set; }
    }
}
