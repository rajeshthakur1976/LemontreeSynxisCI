namespace Framework.SynxisCI.Entity
{
    public class CheckAvailability
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RequestorID { get; set; }

        public string ID_Context { get; set; }

        public string CompanyCode { get; set; }

       public string HotelCode { get; set; }

        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string Quantity { get; set; }

        public string AgeQualifyingCode { get; set; }
        public string GuestCount { get; set; }

        public string AvailReqType { get; set; }

        public string SysytemID { get; set; }

    }
}
