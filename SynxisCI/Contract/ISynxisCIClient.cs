using Framework.SynxisCIV1.Entity;
using SynxisCI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.SynxisCIV1.Contract
{
    public interface ISynxisCIClient
    {
        Task<CancelReservationsResponse> CancelReservationsAsync(CancelReservationsRequest request);
        Task<CancelReservationsNotificationResponse> CancelReservationsNotificationAsync(CancelReservationsNotificationRequest request);
        Task<CheckAvailabilityResponse> CheckAvailabilityAsync(CheckAvailability request);
        Task<CreateReservationsResponse> CreateReservationsAsync(BookRoomRequest request);
        Task<CreateReservationsNotificationResponse> CreateReservationsNotificationAsync(CreateReservationsNotificationRequest request);
        Task<GetAllRoomCountsResponse> GetAllRoomCountsAsync(GetAllRoomCountsRequest request);
        Task<GetHotelCacheChangeResponse> GetHotelCacheChangeAsync(GetHotelCacheChangeRequest request);
        Task<GetHotelDetailsResponse> GetHotelDetailsAsync(HotelDetailsRequest request);
        Task<GetSoldRoomCountsResponse> GetSoldRoomCountsAsync(GetSoldRoomCountsRequest request);
        Task<ModifyReservationsResponse> ModifyReservationsAsync(ModifyReservationsRequest request);
        Task<ModifyReservationsNotificationResponse> ModifyReservationsNotificationAsync(ModifyReservationsNotificationRequest request);
        Task<PingResponse> PingAsync(PingRequest request);
        Task<ReadReservationsResponse> ReadReservationsAsync(ReadReservationsRequest request);
        Task<VerifyReservationsResponse> VerifyReservationsAsync(VerifyReservationsRequest request);


    }
}
