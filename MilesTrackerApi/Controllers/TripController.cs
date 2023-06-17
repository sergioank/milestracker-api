using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesTrackerApi.Dto;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using MilesTrackerApi.Repositories;

namespace MilesTrackerApi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class TripController : ControllerBase
	{
        private readonly IMapper _mapper;
        private readonly ITripRepository _TripRepository;

        public TripController(ITripRepository tripRepository, IMapper mapper)
		{
			_mapper = mapper;
			_TripRepository = tripRepository;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDto>>> GetTrips()
        {
            var tripsList = await _TripRepository.GetTripsAsync();
            var tripsDtoList = _mapper.Map<IEnumerable<TripDto>>(tripsList);

            return Ok(tripsDtoList);
        }

        [HttpGet("trip")]
        public async Task<ActionResult<TripDto>> GetTrip(int tripId)
        {
            if (!_TripRepository.TripExists(tripId))
                return NotFound();

            var trip = await _TripRepository.GetTripAsync(tripId);

            if (trip is null)
                return NotFound();

            var tripDto = _mapper.Map<TripDto>(trip);

            return tripDto;
        }

        [HttpPost("addTrip")]
        public async Task<ActionResult> PostTrip(TripDto tripDto)
        {
            if (tripDto is null)
                return BadRequest();

            var trip = _mapper.Map<Trip>(tripDto);

            var response = await _TripRepository.PostTripAsync(trip);

            if (response)
                return Accepted();

            return BadRequest();
        }

        [HttpPatch("editTripInfo")]
        public async Task<ActionResult> EditTrip(int tripId, [FromBody] JsonPatchDocument<TripDto> patchDoc)
        {
            var trip = await _TripRepository.GetTripAsync(tripId);

            if (trip is null)
                return NotFound("THE ID YOU PROVIDED WAS NOT FOUND");

            if (patchDoc is null)
                return BadRequest();

            var tripDto = _mapper.Map<TripDto>(trip);
            patchDoc.ApplyTo(tripDto);
            _mapper.Map(tripDto, trip);

            try
            {
                await _TripRepository.PatchTripAsync(trip);
                return Accepted("THE DATABASE WAS UPDATED");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteTrip")]
        public async Task<ActionResult> DeleteCar(int tripId)
        {
            var trip = await _TripRepository.GetTripAsync(tripId);

            if (trip is null)
                return NotFound();

            try
            {
                await _TripRepository.DeleteTripAsync(trip);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}

