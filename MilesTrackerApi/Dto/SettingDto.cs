using System;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Dto
{
	public class SettingDto
	{
        public int User_Id { get; set; }
        public string Distance_Unit { get; set; }
        public string Fuel_Consumption_Unit { get; set; }
    }
}

