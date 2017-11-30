using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;

namespace ClientTest
{
    public class TcpClient : SoapClient
    {
        public TcpClient(EndpointReference destination) : base(destination)
        {            
        }

        [SoapMethod("RequestResponseMethod")]
        public SoapEnvelope RequestResponseMethod(SoapEnvelope envelope)
        {
            return base.SendRequestResponse("RequestResonseMethod", envelope);
        }
    }
}
