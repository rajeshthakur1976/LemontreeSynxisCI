using LNTSYNXISCLIENT;
using SynxisCIV1.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SynxisCIV1.Contract
{
    interface ISynxisCIClient
    {
        Task<CancelReservationsResponse> CancelReservationsAsync(CancelReservationsRequest request);
        Task<CancelReservationsNotificationResponse> CancelReservationsNotificationAsync(CancelReservationsNotificationRequest request);
        Task<CheckAvailabilityResponse> CheckAvailabilityAsync(CheckAvailability request);
        Task<CreateReservationsResponse> CreateReservationsAsync(CreateReservationsRequest request);
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
