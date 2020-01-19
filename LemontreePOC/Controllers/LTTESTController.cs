using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.SynxisCI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using static ServiceReference1.Ota2004AServiceSoapClient;

namespace LemontreePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LTTESTController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            Ota2004AServiceSoapClient ota2004AServiceSoapClient = new Ota2004AServiceSoapClient(EndpointConfiguration.BasicHttpBinding_Ota2004AServiceSoap);


            var hotelDetails = ota2004AServiceSoapClient.GetHotelDetailsAsync(new HtngHeader1 { From = new From { systemId = "111", Credential = new Credential { password = "Fz4gFXr7rDOD4P8VoItc", userName = "INTERMONGICERT" } } }, new OTA_HotelDescriptiveInfoRQ

            {
                POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = "10", ID_Context = "Synxis", CompanyName = new CompanyName { Code = "WSBE" } } } },
                HotelDescriptiveInfos = new HotelDescriptiveInfo[]
              {

                 new HotelDescriptiveInfo
                 { ChainCode = "7710", HotelCode = "57057",
                 HotelInfo=new HotelInfo(){ SendData="True" },
                 FacilityInfo =new FacilityInfo(){ SendGuestRooms="True", SendMeetingRooms="True", SendRestaurants="True" },
                 Policies=new Policies(){ SendPolicies="True" },
                 AreaInfo=new AreaInfo(){ SendAttractions="True", SendRecreations="True", SendRefPoints="True" },
                 AffiliationInfo=new AffiliationInfo(){ SendAwards="True" }

                },
                 new HotelDescriptiveInfo
                 { ChainCode = "7710", HotelCode = "58957",
                 HotelInfo=new HotelInfo(){ SendData="True" },
                 FacilityInfo =new FacilityInfo(){ SendGuestRooms="True", SendMeetingRooms="True", SendRestaurants="True" },
                 Policies=new Policies(){ SendPolicies="True" },
                 AreaInfo=new AreaInfo(){ SendAttractions="True", SendRecreations="True", SendRefPoints="True" },
                 AffiliationInfo=new AffiliationInfo(){ SendAwards="True" }

                },
                 new HotelDescriptiveInfo
                 { ChainCode = "7710", HotelCode = "58957",
                 HotelInfo=new HotelInfo(){ SendData="True" },
                 FacilityInfo =new FacilityInfo(){ SendGuestRooms="True", SendMeetingRooms="True", SendRestaurants="True" },
                 Policies=new Policies(){ SendPolicies="True" },
                 AreaInfo=new AreaInfo(){ SendAttractions="True", SendRecreations="True", SendRefPoints="True" },
                 AffiliationInfo=new AffiliationInfo(){ SendAwards="True" }

                },
                 new HotelDescriptiveInfo
                 { ChainCode = "7710", HotelCode = "58957",
                 HotelInfo=new HotelInfo(){ SendData="True" },
                 FacilityInfo =new FacilityInfo(){ SendGuestRooms="True", SendMeetingRooms="True", SendRestaurants="True" },
                 Policies=new Policies(){ SendPolicies="True" },
                 AreaInfo=new AreaInfo(){ SendAttractions="True", SendRecreations="True", SendRefPoints="True" },
                 AffiliationInfo=new AffiliationInfo(){ SendAwards="True" }

                }
              }
            }
          ).Result;
            string xmldata = null;
            Utility.TrySerialize(hotelDetails, out xmldata);
            return xmldata;
        }

        private new HotelDescriptiveInfo[] CreateHotel()
        {
            var xx = new HotelDescriptiveInfo[2];
            for (int x = 0; x <= 2; x++)
            {
                xx[x] = new HotelDescriptiveInfo
                {
                    ChainCode = "7710",
                    HotelCode = "58957",
                    HotelInfo = new HotelInfo() { SendData = "True" },
                    FacilityInfo = new FacilityInfo() { SendGuestRooms = "True", SendMeetingRooms = "True", SendRestaurants = "True" },
                    Policies = new Policies() { SendPolicies = "True" },
                    AreaInfo = new AreaInfo() { SendAttractions = "True", SendRecreations = "True", SendRefPoints = "True" },
                    AffiliationInfo = new AffiliationInfo() { SendAwards = "True" }

                };
            }

            return xx;
        }
    }
}