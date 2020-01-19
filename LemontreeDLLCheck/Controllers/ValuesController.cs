using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Framework.SynxisCI;
using Framework.SynxisCI.Contract;
using Framework.SynxisCI.Entity;
using Framework.SynxisCI.Common;
using Lemontree.SynxisCI.Entity;

namespace LemontreeDLLCheck.Controllers
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
        // GET api/values
        [HttpGet]
       
        [Route("GetHotelDetails.aspx")]
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

            var result = synxisCIClient.GetHotelDetailsAsync(hotelDetailRequest).Result;

            string xmlHotelData = null;
            Utility.TrySerialize(result, out xmlHotelData);
            

            return xmlHotelData;
        }

        [Route("BookRoom.aspx")]
        public ActionResult<string> BookRoom()
        {

            ISynxisCIClient synxisCIClient = new SynxisCIClient();
            var BookingDetails = new BookRoomRequest

            {
                CompanyCode = "WSBE",
                ID_Context = "Synxis",
                RequestorID = "10",
                UserID = _configuration["SynxisUserID"],
                Password = _configuration["SynxisPassword"],
                SysytemID = "111",
                AgeQualifyingCode="10",
                RommTypeCode="BUSR",
                NoOfUnits=1,
                RatePlanCode="BAR Promotion BNX CP",
                GuestCount="1",
                CheckIndate="2020-01-19",
                CheckOutDate= "2020-01-20",
                HotelCode="58957",
                ChainCode="7710",
                CardCode="VI",
                CardNo= "4111111111111111",
                CardExpiryDate ="0420",
                CardSeriesCode="123",
                CardHolderName="Rajesh Thakur",
                ResStatus= "Commit",
                EchoToken="Book Room",
                BedTypeCodeSpecified=true,
                Duration= "P1N",
                CustomerSurname="Thakur"

            };

            var result = synxisCIClient.CreateReservationsAsync(BookingDetails).Result;

            string xmldata = null;
            Utility.TrySerialize(result, out xmldata);


            return xmldata;
        }

        [Route("CheckRoomAvailability.aspx")]
        public ActionResult<string> CheckRoomAvailability()
        {
            ISynxisCIClient synxisCIClient = new SynxisCIClient();
            var CheckAvailability = new CheckAvailability()
            {
                AgeQualifyingCode = "10",
                Password = _configuration["SynxisPassword"],
                UserID = _configuration["SynxisUserID"],
                RequestorID = "10",
                //AvailReqType = "Offer",
                AvailReqType = "Room",
                ID_Context = "Synxis",
                CompanyCode = "WSBE",
                CheckInDate = Convert.ToString(System.DateTime.Now.AddDays(1)),
                CheckOutDate = Convert.ToString(System.DateTime.Now.AddDays(3)),
                Quantity = "1",
                GuestCount = "2",
                HotelCode = "58957"

            };
            var resultAvailability = synxisCIClient.CheckAvailabilityAsync(CheckAvailability).Result;

            string xmldata = null;
            Utility.TrySerialize(resultAvailability, out xmldata);

            return xmldata;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
}
