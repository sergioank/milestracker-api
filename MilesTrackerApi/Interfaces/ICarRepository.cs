using MilesTrackerApi.Models;
using System;

namespace MilesTrackerApi.Interfaces
{
	public interface ICarRepository
	{
        Task<ICollection<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(int id);
        Task<bool> PostCarAsync(Car car);
        Task PatchCarAsync(Car car);
        Task DeleteCarAsync(Car car);
        bool CarsEntityExists();
        bool CarExists(int id);
	}
}
