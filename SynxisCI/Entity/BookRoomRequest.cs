using System;
using System.Collections.Generic;
using System.Text;

namespace Lemontree.SynxisCI.Entity
{
    public class BookRoomRequest
    {
        public string AgeQualifyingCode { get; set; }
        public string SysytemID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RequestorID { get; set; }

        public string ID_Context { get; set; }

        public string CompanyCode { get; set; }

        public string RommTypeCode { get; set; }
        public int NoOfUnits { get; set; }
        public string RatePlanCode { get; set; }

        public string GuestCount { get; set; }
        public string CheckIndate { get; set; }
        public string CheckOutDate { get; set; }

        public string HotelCode { get; set; }
        public string ChainCode { get; set; }
        public string CardCode { get; set; }
        public string CardNo { get; set; }

        public string CardExpiryDate { get; set; }
        public string CardSeriesCode { get; set; }
        public string CardHolderName { get; set; }
        public string CustomerSurname { get; set; }

        public string ResStatus { get; set; }
        public string EchoToken { get; set; }
        public bool BedTypeCodeSpecified { get; set; }
        public string Duration { get; set; }

    }
}
