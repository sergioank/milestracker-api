using System;
using MilesTrackerApi.Dto;
using AutoMapper;
using MilesTrackerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MilesTrackerApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using MilesTrackerApi.Models;



namespace MilesTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
	public class FuelLogController : ControllerBase
	{
        private readonly IMapper _mapper;
        private IFuelLogRepository _FuelLogRepository;

        public FuelLogController(IFuelLogRepository fuelLogRepository, IMapper mapper)
		{
			_mapper = mapper;
			_FuelLogRepository = fuelLogRepository;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelLogDto>>> GetFuelLogs()
        {
            var fuelLogsList = await _FuelLogRepository.GetFuelLogsAsync();
            var fuelLogsDtoList = _mapper.Map<IEnumerable<FuelLogDto>>(fuelLogsList);

            return Ok(fuelLogsDtoList);
        }

        [HttpGet("fuelLog")]
        public async Task<ActionResult<FuelLogDto>> GetFuelLog(int fuelLogId)
        {
            if (!_FuelLogRepository.FuelLogExists(fuelLogId))
                return NotFound();

            var fuelLog = await _FuelLogRepository.GetFuelLogAsync(fuelLogId);

            if (fuelLog is null)
                return NotFound();

            var fuelLogDto = _mapper.Map<FuelLogDto>(fuelLog);

            return fuelLogDto;
        }

        [HttpPost("addFuelLog")]
        public async Task<ActionResult> PostFuelLog(FuelLogDto fuelLogDto)
        {
            if (fuelLogDto is null)
                return BadRequest();

            var fuelLog = _mapper.Map<Fuel_log>(fuelLogDto);

            var response = await _FuelLogRepository.PostFuelLogAsync(fuelLog);

            if (response)
                return Accepted();

            return BadRequest();
        }

        [HttpPatch("editFuelLogInfo")]
        public async Task<ActionResult> EditFuelLog(int fuelLogId, [FromBody] JsonPatchDocument<FuelLogDto> patchDoc)
        {
            var fuelLog = await _FuelLogRepository.GetFuelLogAsync(fuelLogId);

            if (fuelLog is null)
                return NotFound("THE ID YOU PROVIDED WAS NOT FOUND");

            if (patchDoc is null)
                return BadRequest();

            var fuelLogDto = _mapper.Map<FuelLogDto>(fuelLog);
            patchDoc.ApplyTo(fuelLogDto);
            _mapper.Map(fuelLogDto, fuelLog);

            try
            {
                await _FuelLogRepository.PatchFuelLogAsync(fuelLog);
                return Accepted("THE DATABASE WAS UPDATED");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteFuelLog")]
        public async Task<ActionResult> DeleteFuelLog(int fuelLogId)
        {
            var fuelLog = await _FuelLogRepository.GetFuelLogAsync(fuelLogId);

            if (fuelLog is null)
                return NotFound();

            try
            {
                await _FuelLogRepository.DeleteFuelLogAsync(fuelLog);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}

