using LNTSYNXISCLIENT;
using SynxisCIV1.Contract;
using SynxisCIV1.Entity;
using System;
using System.Threading.Tasks;
using static LNTSYNXISCLIENT.Ota2004AServiceSoapClient;

namespace SynxisCIV1
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
            var soapBody = new OTA_HotelAvailRQ() { POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = request.RequestorID, ID_Context = request.ID_Context, CompanyName = new CompanyName { Code = request .CompanyCode} } } }, AvailRequestSegments = new AvailRequestSegment[] { new AvailRequestSegment() { AvailReqType = request.AvailReqType, StayDateRange = new StayDateRangeType() { Start = request.StartDate, End = request.Enddate }, RoomStayCandidates = new RoomStayCandidate[] { new RoomStayCandidate() { Quantity = request.Quantity, GuestCounts = new GuestCount[] { new GuestCount() { AgeQualifyingCode = request.AgeQualifyingCode, Count = request.Count} } } }, HotelSearchCriteria = new HotelSearchCriterion[] { new HotelSearchCriterion() {   HotelRef = new HotelReferenceGroup() { HotelCode = request.HotelCode, } } } } } };
            var result=  await ota2004AServiceSoapClient.CheckAvailabilityAsync(soapHeader, soapBody);
            return result;
        }

        public Task<CreateReservationsResponse> CreateReservationsAsync(CreateReservationsRequest request)
        {
            throw new NotImplementedException();
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
            { POS = new POS { Source = new Source { RequestorId = new RequestorID { ID = hotelDetailsRequest.RequestorID, ID_Context = hotelDetailsRequest.ID_Context, CompanyName = new CompanyName { Code = hotelDetailsRequest .CompanyCode} } } }, HotelDescriptiveInfos = new HotelDescriptiveInfo[] { new HotelDescriptiveInfo { ChainCode = hotelDetailsRequest.ChainCode, HotelCode = hotelDetailsRequest.HotelCode } } };
            var result= await ota2004AServiceSoapClient.GetHotelDetailsAsync(soapHeader, soapBody);
            return result;
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
