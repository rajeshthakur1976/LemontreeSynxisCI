using SynxisService;
using System;
using System.Threading.Tasks;
using static SynxisService.Ota2004AServiceSoapClient;

namespace BAL
{
    public  class SynxisClient
    {
        public Task<GetHotelDetailsResponse> GetHotelDetailsAsyncdd()
        {
            Ota2004AServiceSoapClient ota2004AServiceSoapClient = new Ota2004AServiceSoapClient(EndpointConfiguration.BasicHttpBinding_Ota2004AServiceSoap);

            var result= ota2004AServiceSoapClient.GetHotelDetailsAsync(new HtngHeader1 { From = new From { systemId = "111", Credential = new Credential { password = "Fz4gFXr7rDOD4P8VoItc", userName = "INTERMONGICERT" } } }, new OTA_HotelDescriptiveInfoRQ
            { POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = "10", ID_Context = "Synxis", CompanyName = new CompanyName { Code = "WSBE" } } } }, HotelDescriptiveInfos = new HotelDescriptiveInfo[] { new HotelDescriptiveInfo { ChainCode = "9139", HotelCode = "11206" } } }
           );

           return result;
        }
    }
}
