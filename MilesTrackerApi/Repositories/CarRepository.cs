using System;
using Microsoft.EntityFrameworkCore;
using MilesTrackerApi.Data;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Repositories
{
	public class CarRepository : ICarRepository
	{
        private readonly DataContext _context;

        public CarRepository(DataContext context)
		{
            _context = context;
        }

        public bool CarExists(int id)
        {
            return _context.Cars.Any(c => c.Id == id);
        }

        public bool CarsEntityExists()
        {
            var carsExists = _context.Cars != null ? true : false;
            return carsExists;
        }

        public async Task DeleteCarAsync(Car car)
        {
            if (!CarsEntityExists())
                return;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            return car;
        }

        public async Task<ICollection<Car>> GetCarsAsync()
        {
            var carsList = await _context.Cars.ToListAsync();
            return carsList;
        }

        public async Task<bool> PostCarAsync(Car car)
        {
            var carsExists = CarsEntityExists();
            if (!carsExists)
                return false;

            try
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw (ex);
                return false;
            }

            return true;

        }

        public async Task PatchCarAsync(Car car)
        {
            try
            {
                _context.Cars.Update(car);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

