using System.Collections.Generic;

namespace Framework.SynxisCI.Entity
{
    public class HotelDetailsRequest
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RequestorID { get; set; }
        public string ID_Context { get; set; }
        public string CompanyCode { get; set; }
        public string SysytemID { get; set; }
        public List<PropertyInfo> Hotels { get; set; }
    }

    public class PropertyInfo
    {
        public string ChainID { get; set; }
        public string HodelID { get; set; }
    }
}
