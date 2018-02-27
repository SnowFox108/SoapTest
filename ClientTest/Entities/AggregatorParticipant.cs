using System.Xml.Serialization;

namespace ClientTest.Entities
{
    public class AggregatorParticipant
    {
        [XmlAttribute]
        public string SequenceNumber { get; set; }
        public string Name { get; set; }
        public string AggregatorID { get; set; }
    }
}
