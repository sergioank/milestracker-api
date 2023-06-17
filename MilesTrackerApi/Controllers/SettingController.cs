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
	public class SettingController : ControllerBase
	{
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settingRepository;

        public SettingController(ISettingRepository settingRepository, IMapper mapper)
		{
			_mapper = mapper;
			_settingRepository = settingRepository;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettingDto>>> GetSettings()
        {
            var settingsList = await _settingRepository.GetSettingsAsync();
            var settingsDtoList = _mapper.Map<IEnumerable<SettingDto>>(settingsList);

            return Ok(settingsDtoList);
        }

        [HttpGet("setting")]
        public async Task<ActionResult<SettingDto>> GetSetting(int settingId)
        {
            if (!_settingRepository.SettingExists(settingId))
                return NotFound();

            var setting = await _settingRepository.GetSettingAsync(settingId);

            if (setting is null)
                return NotFound();

            var settingDto = _mapper.Map<SettingDto>(setting);

            return settingDto;
        }

        [HttpPost("addSetting")]
        public async Task<ActionResult> PostSetting(SettingDto settingDto)
        {
            if (settingDto is null)
                return BadRequest();

            var setting = _mapper.Map<Setting>(settingDto);

            var response = await _settingRepository.PostSettingAsync(setting);

            if (response)
                return Accepted();

            return BadRequest();
        }

        [HttpPatch("editSettingInfo")]
        public async Task<ActionResult> EditCar(int settingId, [FromBody] JsonPatchDocument<SettingDto> patchDoc)
        {
            var setting = await _settingRepository.GetSettingAsync(settingId);

            if (setting is null)
                return NotFound("THE ID YOU PROVIDED WAS NOT FOUND");

            if (patchDoc is null)
                return BadRequest();

            var settingDto = _mapper.Map<SettingDto>(setting);
            patchDoc.ApplyTo(settingDto);
            _mapper.Map(settingDto, setting);

            try
            {
                await _settingRepository.PatchSettingAsync(setting);
                return Accepted("THE DATABASE WAS UPDATED");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteSetting")]
        public async Task<ActionResult> DeleteCar(int settingId)
        {
            var setting = await _settingRepository.GetSettingAsync(settingId);

            if (setting is null)
                return NotFound();

            try
            {
                await _settingRepository.DeleteSettingAsync(setting);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}

