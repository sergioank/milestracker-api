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
	public class MaintenanceController : ControllerBase
	{
        private readonly IMapper _mapper;
        private readonly IMaintenanceRepository _maintenanceRepository;

        public MaintenanceController(IMaintenanceRepository maintenanceRepository, IMapper mapper)
		{
			_mapper = mapper;
			_maintenanceRepository = maintenanceRepository;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceDto>>> GetMaintenances()
        {
            var maintenancesList = await _maintenanceRepository.GetMaintenancesAsync();
            var maintenancesDtoList = _mapper.Map<IEnumerable<MaintenanceDto>>(maintenancesList);

            return Ok(maintenancesDtoList);
        }

        [HttpGet("maintenance")]
        public async Task<ActionResult<MaintenanceDto>> GetMaintenance(int maintenanceId)
        {
            if (!_maintenanceRepository.MaintenanceExists(maintenanceId))
                return NotFound();

            var maintenance = await _maintenanceRepository.GetMaintenanceAsync(maintenanceId);

            if (maintenance is null)
                return NotFound();

            var maintenanceDto = _mapper.Map<MaintenanceDto>(maintenance);

            return maintenanceDto;
        }

        [HttpPost("addMaintenance")]
        public async Task<ActionResult> PostMaintenance(MaintenanceDto maintenanceDto)
        {
            if (maintenanceDto is null)
                return BadRequest();

            var maintenance = _mapper.Map<Maintenance>(maintenanceDto);

            var response = await _maintenanceRepository.PostMaintenanceAsync(maintenance);

            if (response)
                return Accepted();

            return BadRequest();
        }

        [HttpPatch("editMaintenanceInfo")]
        public async Task<ActionResult> EditMaintenance(int maintenanceId, [FromBody] JsonPatchDocument<MaintenanceDto> patchDoc)
        {
            var maintenance = await _maintenanceRepository.GetMaintenanceAsync(maintenanceId);

            if (maintenance is null)
                return NotFound("THE ID YOU PROVIDED WAS NOT FOUND");

            if (patchDoc is null)
                return BadRequest();

            var maintenanceDto = _mapper.Map<MaintenanceDto>(maintenance);
            patchDoc.ApplyTo(maintenanceDto);
            _mapper.Map(maintenanceDto, maintenance);

            try
            {
                await _maintenanceRepository.PatchMaintenanceAsync(maintenance);
                return Accepted("THE DATABASE WAS UPDATED");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteMaintenance")]
        public async Task<ActionResult> DeleteCar(int maintenanceId)
        {
            var maintenance = await _maintenanceRepository.GetMaintenanceAsync(maintenanceId);

            if (maintenance is null)
                return NotFound();

            try
            {
                await _maintenanceRepository.DeleteMaintenanceAsync(maintenance);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}

