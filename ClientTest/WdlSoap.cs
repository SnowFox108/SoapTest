using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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

            var client = new MySellingService.SellingDistributionAdapterPortTypeClient();
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

            airShopping.Travelers = new TravelersTraveler[]
            {
                new TravelersTraveler()
                {
                    AnonymousTraveler = new AnonymousTravelerType[]
                    {
                        new AnonymousTravelerType()
                        {
                            PTC = new TravelerCoreTypePTC(){ Quantity = "1", Value = "ADT"},
                            Age = new TravelerCoreTypeAge() {Item = new TravelerCoreTypeAgeBirthDate()
                                {
                                   Value  = new DateTime(1988,06,07)
                                }
                            }
                        }
                    }
                }                
            };

            airShopping.CoreQuery = new AirShoppingRQCoreQuery()
            {
                Item = new AirShopReqAttributeQueryType()
                {
                    OriginDestination = new AirShopReqAttributeQueryTypeOriginDestination[]
                    {
                        new AirShopReqAttributeQueryTypeOriginDestination()
                        {
                            Departure = new Departure()
                            {
                                AirportCode = new FlightDepartureTypeAirportCode()
                                {
                                    Value = "LHR"
                                },
                                Date = new DateTime(2018,08,26)                                
                            },
                            Arrival = new FlightArrivalType()
                            {
                                AirportCode = new FlightArrivalTypeAirportCode()
                                {
                                    Value = "DME"
                                }                            
                            }
                        },
                        new AirShopReqAttributeQueryTypeOriginDestination()
                        {
                            Departure = new Departure()
                            {
                                AirportCode = new FlightDepartureTypeAirportCode()
                                {
                                    Value = "DME"
                                },
                                Date = new DateTime(2018,09,26)
                            },
                            Arrival = new FlightArrivalType()
                            {
                                AirportCode = new FlightArrivalTypeAirportCode()
                                {
                                    Value = "LHR"
                                }
                            }
                        }, 
                    }
                }
            };

            airShopping.Preference = new AirShoppingRQPreference()
            {
                FarePreferences = new FarePreferencesType()
                {
                    Types = new FarePreferencesTypeType[]
                    {
                        new FarePreferencesTypeType()
                        {
                            Code = "759"
                        }, 
                    }
                },
                CabinPreferences = new CabinPreferencesType()
                {
                    CabinType = new CabinType[]
                    {
                        new CabinType()
                        {
                            Code = "5"
                        }, 
                    }
                }
            };

            using (new OperationContextScope(client.InnerChannel))
            {
                // Add a HTTP Header to an outgoing request
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Client-key"] = "f96fe4th2dt45kd2m43ayktx";
                requestMessage.Headers["SOAPAction"] = "AirShoppingV01";
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                var result = client.AirShoppingV01(new AirShoppingRQV01(airShopping));
            }

            //Console.WriteLine(response);
        }
    }
}
