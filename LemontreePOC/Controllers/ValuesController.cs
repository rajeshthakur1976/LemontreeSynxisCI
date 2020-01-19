using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Framework.SynxisCI;
using Framework.SynxisCI.Contract;
using Framework.SynxisCI.Entity;
using Framework.SynxisCI.Common;

namespace LemontreePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
            // SynxisCIClient synxisCIClient = new SynxisCIClient();
        }

        [HttpGet]
        [Route("GetHotelDetails")]
        public ActionResult<string> GetHotelDetails()
        {
            ISynxisCIClient synxisCIClient = new SynxisCIClient();
            var hotelDetailRequest = new HotelDetailsRequest

            {
                CompanyCode = "WSBE",
                ID_Context = "Synxis",
                RequestorID = "10",
                UserID = _configuration["SynxisUserID"],
                Password = _configuration["SynxisPassword"],
                SysytemID = "111",
                Hotels = new List<PropertyInfo>() { new PropertyInfo() { ChainID = "7710", HodelID = "57057" }, new PropertyInfo() { ChainID = "7710", HodelID = "58957" } }
            };

            var result = synxisCIClient.GetHotelDetailsAsync(hotelDetailRequest);

            string xmldata = null;
            Utility.TrySerialize(result, out xmldata);
            return xmldata;
          
        }
        GET api/values
       [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //LMNTcls lMNTcls = new LMNTcls();
            //lMNTcls.PingAsync(new PingRequest() { });


            //HotelDetailsRequest hotelDetailsRequest = new HotelDetailsRequest()
            //{
            //    ChainCode = "7710",
            //    HotelCode = "57057",
            //    CompanyCode = "WSBE",
            //    ID_Context = "Synxis",
            //    RequestorID = "10",
            //    UserID = _configuration["SynxisUserID"],
            //    Password = _configuration["SynxisPassword"],
            //    SysytemID = "111"

            //};

            //var result = synxisCIClient.GetHotelDetailsAsync(hotelDetailsRequest).Result;

            //ISynxisCIClient synxisCIClient = new SynxisCIClient();
            //var CheckAvailability = new CheckAvailability()
            //{
            //    AgeQualifyingCode = "10",
            //    Password = _configuration["SynxisPassword"],
            //    UserID = _configuration["SynxisUserID"],
            //    RequestorID = "10",
            //    //AvailReqType = "Offer",
            //    AvailReqType = "Room",
            //    ID_Context = "Synxis",
            //    CompanyCode = "WSBE",
            //    CheckInDate = Convert.ToString(System.DateTime.Now.AddDays(1)),
            //    CheckOutDate = Convert.ToString(System.DateTime.Now.AddDays(3)),
            //    Quantity = "1",
            //    GuestCount = "2",
            //    HotelCode = "58957"

            //};


            //var resultAvailability = synxisCIClient.CheckAvailabilityAsync(CheckAvailability).Result;

            //string xmldata = null;
            //Utility.TrySerialize(resultAvailability, out xmldata);


            //int x = 200;
            //SynxisClient synxisClient = new SynxisClient();
            //var result = synxisClient.GetHotelDetailsAsyncdd().Result;
            //Ota2004AServiceSoapClient ota2004AServiceSoapClient = new Ota2004AServiceSoapClient(EndpointConfiguration.BasicHttpBinding_Ota2004AServiceSoap);

            //var result = ota2004AServiceSoapClient.PingAsync(new HtngHeader1 { From = new From { systemId = "111", Credential = new Credential { password = "Fz4gFXr7rDOD4P8VoItc", userName = "INTERMONGICERT" } } }, new OTA_PingRQ { }).Result;

            //var hotelDetails = ota2004AServiceSoapClient.GetHotelDetailsAsync(new HtngHeader1 { From = new From { systemId = "111", Credential = new Credential { password = "Fz4gFXr7rDOD4P8VoItc", userName = "INTERMONGICERT" } } }, new OTA_HotelDescriptiveInfoRQ

            //{ POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = "10", ID_Context = "Synxis", CompanyName = new CompanyName { Code = "WSBE" } } } }, HotelDescriptiveInfos = new HotelDescriptiveInfo[] { new HotelDescriptiveInfo { ChainCode = "7710", HotelCode = "57057" } } }
            //).Result;

            //var hotelDetails = ota2004AServiceSoapClient.GetHotelDetailsAsync(new HtngHeader1 { From = new From { systemId = "111", Credential = new Credential { password = "Fz4gFXr7rDOD4P8VoItc", userName = "INTERMONGICERT" } } }, new OTA_HotelDescriptiveInfoRQ

            //{ POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = "10", ID_Context = "Synxis", CompanyName = new CompanyName { Code = "WSBE" } } } }, HotelDescriptiveInfos = new HotelDescriptiveInfo[] { new HotelDescriptiveInfo { ChainCode = "7710", HotelCode = "57057", HotelInfo=new HotelInfo() {  SendData="True"}, FacilityInfo=new FacilityInfo() { SendMeetingRooms="True", SendGuestRooms="True",SendRestaurants="True" }, Policies=new Policies() {  SendPolicies="True"},AreaInfo=new AreaInfo() { SendAttractions="True", SendRecreations="True" },AffiliationInfo=new AffiliationInfo() {SendAwards="True" } } } }
            //).Result;


            //string xmldata = null;
            //Utility.TrySerialize(hotelDetails, out xmldata);

            //  var xmldataAvailability = ota2004AServiceSoapClient.CheckAvailabilityAsync(new HtngHeader1 { From = new From { systemId = "111", Credential = new Credential { password = "Fz4gFXr7rDOD4P8VoItc", userName = "INTERMONGICERT" } } }
            //  , new OTA_HotelAvailRQ() { POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = "10", ID_Context = "Synxis", CompanyName = new CompanyName { Code = "WSBE" } } } }, AvailRequestSegments = new AvailRequestSegment[] { new AvailRequestSegment() { AvailReqType = "Room", StayDateRange = new StayDateRangeType() { Start = "2019-12-01", End = "2019-12-02" }, RoomStayCandidates = new RoomStayCandidate[] { new RoomStayCandidate() { Quantity = "1", GuestCounts = new GuestCount[] { new GuestCount() { AgeQualifyingCode = "10", Count = "1" } } } }, HotelSearchCriteria = new HotelSearchCriterion[] { new HotelSearchCriterion() { HotelRef = new HotelReferenceGroup() { HotelCode = "58957" } } } } } }
            //).Result;

            //  string xmldataAvailabilityresult = null;
            //  Utility.TrySerialize(xmldataAvailability, out xmldataAvailabilityresult);

            return new string[] { "value1", "value2" };
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            ISynxisCIClient synxisCIClient = new SynxisCIClient();
            var hotelDetailRequest = new HotelDetailsRequest

            {
                CompanyCode = "WSBE",
                ID_Context = "Synxis",
                RequestorID = "10",
                UserID = _configuration["SynxisUserID"],
                Password = _configuration["SynxisPassword"],
                SysytemID = "111",
                Hotels = new List<PropertyInfo>() { new PropertyInfo() { ChainID = "7710", HodelID = "57057" }, new PropertyInfo() { ChainID = "7710", HodelID = "58957" } }
            };

            var result = synxisCIClient.GetHotelDetailsAsync(hotelDetailRequest);

            string xmldata = null;
            Utility.TrySerialize(result, out xmldata);
            return xmldata;

            
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    //public class LMNTcls : Ota2004AServiceSoap
    //{
    //    public Task<CancelReservationsResponse> CancelReservationsAsync(CancelReservationsRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<CancelReservationsNotificationResponse> CancelReservationsNotificationAsync(CancelReservationsNotificationRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<CheckAvailabilityResponse> CheckAvailabilityAsync(CheckAvailabilityRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<CreateReservationsResponse> CreateReservationsAsync(CreateReservationsRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<CreateReservationsNotificationResponse> CreateReservationsNotificationAsync(CreateReservationsNotificationRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<GetAllRoomCountsResponse> GetAllRoomCountsAsync(GetAllRoomCountsRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<GetHotelCacheChangeResponse> GetHotelCacheChangeAsync(GetHotelCacheChangeRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<GetHotelDetailsResponse> GetHotelDetailsAsync(GetHotelDetailsRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<GetSoldRoomCountsResponse> GetSoldRoomCountsAsync(GetSoldRoomCountsRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<ModifyReservationsResponse> ModifyReservationsAsync(ModifyReservationsRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<ModifyReservationsNotificationResponse> ModifyReservationsNotificationAsync(ModifyReservationsNotificationRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<PingResponse> PingAsync(PingRequest request)
    //    {
    //        //HtngHeader1 htngHeader1 = new HtngHeader1();
    //        //// htngHeader1.From.systemId = "55555";
           
    //        //htngHeader1.From.Credential.userName = "INTERMONGICERT";
    //        //htngHeader1.From.Credential.password = "Fz4gFXr7rDOD4P8VoItc";

    //        //OTA_PingRQ oTA_PingRQ = new OTA_PingRQ();
           
    //        Ota2004AServiceSoapClient ota2004AServiceSoapClient = new Ota2004AServiceSoapClient(EndpointConfiguration.BasicHttpBinding_Ota2004AServiceSoap);
       
    //        var result= ota2004AServiceSoapClient.PingAsync(new HtngHeader1 { From= new From { systemId="111", Credential=new Credential { password= "Fz4gFXr7rDOD4P8VoItc", userName= "INTERMONGICERT" } } },new OTA_PingRQ { }).Result;
          
           
    //    }

    //    public Task<ReadReservationsResponse> ReadReservationsAsync(ReadReservationsRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<VerifyReservationsResponse> VerifyReservationsAsync(VerifyReservationsRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
