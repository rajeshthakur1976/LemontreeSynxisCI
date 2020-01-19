using System;
using System.Collections.Generic;
using System.Text;

namespace SynxisCIV1.Entity
{
    public class HotelDetailsRequest
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RequestorID { get; set; }

        public string ID_Context { get; set; }

        public string CompanyCode { get; set; }

        public string ChainCode { get; set; }

        public string HotelCode { get; set; }

        public string SysytemID { get; set; }
    }
}
