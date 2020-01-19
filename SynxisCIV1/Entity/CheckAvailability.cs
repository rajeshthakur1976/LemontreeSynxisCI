using System;
using System.Collections.Generic;
using System.Text;

namespace SynxisCIV1.Entity
{
    public class CheckAvailability
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RequestorID { get; set; }

        public string ID_Context { get; set; }

        public string CompanyCode { get; set; }

       public string HotelCode { get; set; }

        public string StartDate { get; set; }
        public string Enddate { get; set; }
        public string Quantity { get; set; }

        public string AgeQualifyingCode { get; set; }
        public string Count { get; set; }

        public string AvailReqType { get; set; }

        public string SysytemID { get; set; }

    }
}
