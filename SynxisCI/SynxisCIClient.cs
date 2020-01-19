using Framework.SynxisCI.Contract;
using Framework.SynxisCI.Entity;
using Lemontree.SynxisCI.Entity;
using SynxisCI;
using System;
using System.Threading.Tasks;
using static SynxisCI.Ota2004AServiceSoapClient;

namespace Framework.SynxisCI
{
    public class SynxisCIClient : ISynxisCIClient
    {
        private readonly Ota2004AServiceSoapClient ota2004AServiceSoapClient;
        public SynxisCIClient()
        {
            ota2004AServiceSoapClient = new Ota2004AServiceSoapClient(EndpointConfiguration.BasicHttpBinding_Ota2004AServiceSoap);
        }

        public Task<CancelReservationsResponse> CancelReservationsAsync(CancelReservationsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CancelReservationsNotificationResponse> CancelReservationsNotificationAsync(CancelReservationsNotificationRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CheckAvailabilityResponse> CheckAvailabilityAsync(CheckAvailability request)
        {
            var soapHeader=new HtngHeader1 { From = new From { systemId = request.SysytemID, Credential = new Credential { password = request.Password, userName = request.UserID } } };

            var soapBody = new OTA_HotelAvailRQ() { POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = request.RequestorID, ID_Context = request.ID_Context, CompanyName = new CompanyName { Code = request .CompanyCode} } } }, AvailRequestSegments = new AvailRequestSegment[] { new AvailRequestSegment() { AvailReqType = request.AvailReqType, StayDateRange = new StayDateRangeType() { Start = request.CheckInDate, End = request.CheckOutDate }, RoomStayCandidates = new RoomStayCandidate[] { new RoomStayCandidate() { Quantity = request.Quantity, GuestCounts = new GuestCount[] { new GuestCount() { AgeQualifyingCode = request.AgeQualifyingCode, Count = request.GuestCount} } } }, HotelSearchCriteria = new HotelSearchCriterion[] { new HotelSearchCriterion() {   HotelRef = new HotelReferenceGroup() { HotelCode = request.HotelCode, } } } } } };
            var result=  await ota2004AServiceSoapClient.CheckAvailabilityAsync(soapHeader, soapBody);
            return result;
        }

        public async Task<CreateReservationsResponse> CreateReservationsAsync(BookRoomRequest request)
        {
            var soapHeader = new HtngHeader1 { From = new From { systemId = request.SysytemID, Credential = new Credential { password = request.Password, userName = request.UserID } } };
            var soapBody = new OTA_HotelResRQ
            {
                POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = request.RequestorID, ID_Context = request.ID_Context, CompanyName = new CompanyName { Code = request.CompanyCode } } } },
                EchoToken=request.EchoToken,ResStatus= request.ResStatus,
                 HotelReservations=new HotelReservation[] 
                 {
                     new HotelReservation()
                     {
                         RoomStayReservation =true,
                         RoomStays=new RoomStay[]
                         {
                             new RoomStay(){ RoomTypes=new RoomType[]{new RoomType(){ NumberOfUnits = request.NoOfUnits, RoomTypeCode=request.RommTypeCode,  BedTypeCodeSpecified=request.BedTypeCodeSpecified, NumberOfUnitsSpecified=true  }},
                               RatePlans=new RatePlan[] { new RatePlan() { RatePlanCode= request.RatePlanCode } },
                               GuestCounts=new GuestCounts(){ GuestCount=new GuestCount[]{ new GuestCount() { AgeQualifyingCode=request.AgeQualifyingCode, Count=request.GuestCount } }},
                             
                              TimeSpan=new DateTimeSpanType(){ Start=request.CheckIndate, End=request.CheckOutDate, Duration=request.Duration },
                               BasicPropertyInfo=new HotelReferenceGroup(){ HotelCode=request.HotelCode, ChainCode=request.ChainCode }

                             } },
                         

                         ResGuests=new ResGuest[]{ new ResGuest() { Profiles=new ProfileInfo[] { new ProfileInfo() {  Profile=new Profile() {  Customer=new Customer() {  PersonName=new PersonName[] { new PersonName() { Surname=request.CustomerSurname } } } } } } } },
                         ResGlobalInfo=new ResGlobalInfo(){  Guarantee=new Guarantee(){  GuaranteesAccepted=new GuaranteeAccepted[]{ new GuaranteeAccepted { PaymentCard=new PaymentCard() { CardCode=request.CardCode, CardNumber=request.CardNo, ExpireDate=request.CardExpiryDate, SeriesCode=request.CardSeriesCode, CardHolderName=request.CardHolderName } } } } }

                     }
                 }

            };

            var result = await ota2004AServiceSoapClient.CreateReservationsAsync(soapHeader, soapBody);
            return result;
        }

        public Task<CreateReservationsNotificationResponse> CreateReservationsNotificationAsync(CreateReservationsNotificationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllRoomCountsResponse> GetAllRoomCountsAsync(GetAllRoomCountsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetHotelCacheChangeResponse> GetHotelCacheChangeAsync(GetHotelCacheChangeRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GetHotelDetailsResponse> GetHotelDetailsAsync(HotelDetailsRequest  hotelDetailsRequest)
        {
           var soapHeader= new HtngHeader1 {  From = new From { systemId = hotelDetailsRequest.SysytemID, Credential = new Credential { password = hotelDetailsRequest.Password, userName = hotelDetailsRequest.UserID } } };
            var soapBody = new OTA_HotelDescriptiveInfoRQ
            { POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = hotelDetailsRequest.RequestorID, ID_Context = hotelDetailsRequest.ID_Context, CompanyName = new CompanyName { Code = hotelDetailsRequest .CompanyCode} } } },

                HotelDescriptiveInfos = GetHotels(hotelDetailsRequest)
            };
            var result= await ota2004AServiceSoapClient.GetHotelDetailsAsync(soapHeader, soapBody);
            return result;
        }
        
        private new HotelDescriptiveInfo[] GetHotels(HotelDetailsRequest hotelDetailsRequest)
        {
            var xx = new HotelDescriptiveInfo[hotelDetailsRequest.Hotels.Count];
            for (int x = 0; x <= hotelDetailsRequest.Hotels.Count-1; x++)
            {
                xx[x] = new HotelDescriptiveInfo
                {
                    ChainCode = hotelDetailsRequest.Hotels[x].ChainID,
                    HotelCode = hotelDetailsRequest.Hotels[x].HodelID,
                    HotelInfo = new HotelInfo() { SendData = "True" },
                    FacilityInfo = new FacilityInfo() { SendGuestRooms = "True", SendMeetingRooms = "True", SendRestaurants = "True" },
                    Policies = new Policies() { SendPolicies = "True" },
                    AreaInfo = new AreaInfo() { SendAttractions = "True", SendRecreations = "True", SendRefPoints = "True" },
                    AffiliationInfo = new AffiliationInfo() { SendAwards = "True" }

                };
            }

            return xx;
        }

        public Task<GetSoldRoomCountsResponse> GetSoldRoomCountsAsync(GetSoldRoomCountsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ModifyReservationsResponse> ModifyReservationsAsync(ModifyReservationsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ModifyReservationsNotificationResponse> ModifyReservationsNotificationAsync(ModifyReservationsNotificationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PingResponse> PingAsync(PingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ReadReservationsResponse> ReadReservationsAsync(ReadReservationsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<VerifyReservationsResponse> VerifyReservationsAsync(VerifyReservationsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
