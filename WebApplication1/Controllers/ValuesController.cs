using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Framework.SynxisCIV1;
using Framework.SynxisCIV1.Contract;
using Framework.SynxisCIV1.Entity;
using Framework.SynxisCIV1.Common;

namespace WebApplication1.Controllers
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
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


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
                Hotels = new List<HotelDetails>() { new HotelDetails() { ChainID = "7710", HodelID = "57057" }, new HotelDetails() { ChainID = "7710", HodelID = "58957" } }
            };

            var result = synxisCIClient.GetHotelDetailsAsync(hotelDetailRequest).Result;

            string xmlHotelData = null;
            Utility.TrySerialize(result, out xmlHotelData);


            return xmlHotelData;
            return "";
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
