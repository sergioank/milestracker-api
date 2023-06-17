using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesTrackerApi.Dto;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;
using Microsoft.AspNetCore.JsonPatch;


namespace MilesTrackerApi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class CarsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICarRepository _carRepository;

		public CarsController(ICarRepository carRepository, IMapper mapper)
		{
			_mapper = mapper;
			_carRepository = carRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
		{
			var carsList = await _carRepository.GetCarsAsync();
			var carsDtoList = _mapper.Map<IEnumerable<CarDto>>(carsList);

			return Ok(carsDtoList);
		}

		[HttpGet("car")]
		public async Task<ActionResult<CarDto>> GetCar(int id)
		{
			if (!_carRepository.CarExists(id))
				return NotFound();

			var car = await _carRepository.GetCarAsync(id);

			if (car is null)
				return NotFound();

			var carDto = _mapper.Map<CarDto>(car);

			return carDto;
		}

		[HttpPost("addCar")]
		public async Task<ActionResult> PostCar(CarDto carDto)
		{
			if (carDto is null)
				return BadRequest();

			var car = _mapper.Map<Car>(carDto);

			var response = await _carRepository.PostCarAsync(car);

			if (response)
				return Accepted();

			return BadRequest();
		}

		[HttpPatch("editCarInfo")]
		public async Task<ActionResult> EditCar(int id, [FromBody]JsonPatchDocument<CarDto> patchDoc)
		{
			var car = await _carRepository.GetCarAsync(id);

			if (car is null)
				return NotFound("THE ID YOU PROVIDED WAS NOT FOUND");

			if (patchDoc is null)
				return BadRequest();

			var carDto = _mapper.Map<CarDto>(car);
			patchDoc.ApplyTo(carDto);
			_mapper.Map(carDto, car);

			try
			{
				await _carRepository.PatchCarAsync(car);
				return Accepted("THE DATABASE WAS UPDATED");
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}

		[HttpDelete("deleteCar")]
		public async Task<ActionResult> DeleteCar(int id)
		{
			var car = await _carRepository.GetCarAsync(id);

			if (car is null)
				return NotFound();

			try
			{
				await _carRepository.DeleteCarAsync(car);
				return Accepted();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}

		}
	}
}

