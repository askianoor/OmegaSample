using OmegaSample.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaSample.Services
{
    public interface IBookingService
    {
        Task<Booking> GetBookingAsync(Guid bookingId, CancellationToken ct);

        Task<Guid> CreateBookingAsync(
            Guid userId,
            Guid roomId,
            DateTimeOffset startAt,
            DateTimeOffset endAt,
            CancellationToken ct);

        Task DeleteBookingAsync(Guid bookingId, CancellationToken ct);
    }
}
