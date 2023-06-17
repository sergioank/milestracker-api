using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MilesTrackerApi.Dto;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;
using MilesTrackerApi.Repositories;

namespace MilesTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VehiclesController : ControllerBase
	{

        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesController(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles()
        {
            var vehiclesList = await _vehicleRepository.GetVehiclesAsync();
            var vehiclesDtoList = _mapper.Map<IEnumerable<VehicleDto>>(vehiclesList);

            return Ok(vehiclesDtoList);
        }

        [HttpGet("vehicle")]
        public async Task<ActionResult<VehicleDto>> GetVehicles(int vehicleId)
        {
            if (!_vehicleRepository.VehicleExists(vehicleId))
                return NotFound();

            var vehicle = await _vehicleRepository.GetVehicleAsync(vehicleId);

            if (vehicle is null)
                return NotFound();

            var vehicleDto = _mapper.Map<VehicleDto>(vehicle);

            return vehicleDto;
        }

        [HttpPost("addVehicle")]
        public async Task<ActionResult> PostVehicle(VehicleDto vehicleDto)
        {
            if (vehicleDto is null)
                return BadRequest();

            var vehicle = _mapper.Map<Vehicle>(vehicleDto);

            var response = await _vehicleRepository.PostVehicleAsync(vehicle);

            if (response)
                return Accepted();

            return BadRequest();
        }

        [HttpPatch("editVehicleInfo")]
        public async Task<ActionResult> EditVehicle(int vehicleId, [FromBody] JsonPatchDocument<VehicleDto> patchDoc)
        {
            var vehicle = await _vehicleRepository.GetVehicleAsync(vehicleId);

            if (vehicle is null)
                return NotFound("THE ID YOU PROVIDED WAS NOT FOUND");

            if (patchDoc is null)
                return BadRequest();

            var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
            patchDoc.ApplyTo(vehicleDto);
            _mapper.Map(vehicleDto, vehicle);

            try
            {
                await _vehicleRepository.PatchVehicleAsync(vehicle);
                return Accepted("THE DATABASE WAS UPDATED");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteVehicle")]
        public async Task<ActionResult> DeleteVehicle(int vehicleId)
        {
            var vehicle = await _vehicleRepository.GetVehicleAsync(vehicleId);

            if (vehicle is null)
                return NotFound();

            try
            {
                await _vehicleRepository.DeleteVehicleAsync(vehicle);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        
    }
}

