using System;
using AutoMapper;
using MilesTrackerApi.Models;
using MilesTrackerApi.Dto;
using System.Drawing;

namespace MilesTrackerApi.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();
			CreateMap<Fuel_log, FuelLogDto>();
			CreateMap<FuelLogDto, Fuel_log>();
			CreateMap<Maintenance, MaintenanceDto>();
			CreateMap<MaintenanceDto, Maintenance>();
			CreateMap<Setting, SettingDto>();
			CreateMap<SettingDto, Setting>();
			CreateMap<Trip, TripDto>();
			CreateMap<TripDto, Trip>();
            CreateMap<User, UserDto>();
			CreateMap<UserDto, User>();
			CreateMap<Vehicle, VehicleDto>();
			CreateMap<VehicleDto, Vehicle>();
        }
	}
}
