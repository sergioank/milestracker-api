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
	public class UserController : ControllerBase
	{
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        public UserController(IUserRepository userRepository, IMapper mapper)
		{
			_mapper = mapper;
			_UserRepository = userRepository;
		}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var usersList = await _UserRepository.GetUsersAsync();
            var usersDtoList = _mapper.Map<IEnumerable<UserDto>>(usersList);

            return Ok(usersDtoList);
        }

        [HttpGet("user")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            if (!_UserRepository.UserExists(userId))
                return NotFound();

            var user = await _UserRepository.GetUserAsync(userId);

            if (user is null)
                return NotFound();

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        [HttpPost("addUser")]
        public async Task<ActionResult> PostUser(UserDto userDto)
        {
            if (userDto is null)
                return BadRequest();

            var user = _mapper.Map<User>(userDto);

            var response = await _UserRepository.PostUserAsync(user);

            if (response)
                return Accepted();

            return BadRequest();
        }

        [HttpPatch("editUserInfo")]
        public async Task<ActionResult> EditCar(int userId, [FromBody] JsonPatchDocument<UserDto> patchDoc)
        {
            var user = await _UserRepository.GetUserAsync(userId);

            if (user is null)
                return NotFound("THE ID YOU PROVIDED WAS NOT FOUND");

            if (patchDoc is null)
                return BadRequest();

            var userDto = _mapper.Map<UserDto>(user);
            patchDoc.ApplyTo(userDto);
            _mapper.Map(userDto, user);

            try
            {
                await _UserRepository.PatchUserAsync(user);
                return Accepted("THE DATABASE WAS UPDATED");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteUser")]
        public async Task<ActionResult> DeleteCar(int userId)
        {
            var user = await _UserRepository.GetUserAsync(userId);

            if (user is null)
                return NotFound();

            try
            {
                await _UserRepository.DeleteUserAsync(user);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}

