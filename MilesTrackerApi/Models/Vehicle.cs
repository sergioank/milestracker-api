using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilesTrackerApi.Models
{
	public class Vehicle
	{
		public int Vehicle_Id { get; set; }

		
		public int User_Id { get; set; }
		public User User { get; set; }

		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string License_Plate { get; set; }
		public int Odometer { get; set; }
		public DateTime Created_At { get; set; }
		public DateTime Updated_At { get; set; }

		public List<Fuel_log> FuelLogs { get; set; }
		public List<Trip> Trips { get; set; }
		public List<Maintenance> Maintenances { get; set; }
    }
}

