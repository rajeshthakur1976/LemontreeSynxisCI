using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SynxisCIV1;
using SynxisCIV1.Entity;
namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {

            SynxisCIClient synxisCIClient = new SynxisCIClient();
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
           
            var CheckAvailability = new CheckAvailability()
            {
                AgeQualifyingCode = "10",
                Password = "Fz4gFXr7rDOD4P8VoItc",
                UserID = "INTERMONGICERT",
                RequestorID = "10",
                //AvailReqType = "Offer",
                AvailReqType = "Room",
                ID_Context = "Synxis",
                CompanyCode = "WSBE",
                StartDate = Convert.ToString(System.DateTime.Now.AddDays(1)),
                Enddate = Convert.ToString(System.DateTime.Now.AddDays(3)),
                Quantity = "1",
                Count = "2",
                HotelCode = "58957"

            };


            var resultAvailability = synxisCIClient.CheckAvailabilityAsync(CheckAvailability).Result;

            string xmldata = null;
            Utility.TrySerialize(resultAvailability, out xmldata);


            int x = 200;
          


            return "";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
