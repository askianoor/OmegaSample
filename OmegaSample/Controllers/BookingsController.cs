﻿using OmegaSample.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaSample.Controllers
{
    [Route("/[controller]")]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // TODO: authorization
        [HttpGet("{bookingId}", Name = nameof(GetBookingByIdAsync))]
        public async Task<IActionResult> GetBookingByIdAsync(
            Guid bookingId,
            CancellationToken ct)
        {
            var booking = await _bookingService.GetBookingAsync(bookingId, ct);
            if (booking == null) return NotFound();

            return Ok(booking);
        }

        [HttpDelete("{bookingId}", Name = nameof(DeleteBookingByIdAsync))]
        public async Task<IActionResult> DeleteBookingByIdAsync(
            Guid bookingId,
            CancellationToken ct)
        {
            // TODO: Authorize that the user is allowed to delete!
            await _bookingService.DeleteBookingAsync(bookingId, ct);
            return NoContent();
        }
    }
}
