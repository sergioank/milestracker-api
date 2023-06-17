using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilesTrackerApi.Models
{
	public class Fuel_log
	{
		[Key]
		public int Fuel_log_id { get; set; }

		[ForeignKey("Vehicle")]
		public int Vehicle_id { get; set; }
		public Vehicle Vehicle { get; set; }

		public DateTime Date { get; set; }
		public float Amount { get; set; }
		public float Cost_per_unit { get; set; }
		public float Total_cost { get; set; }
		public int Odometer_reading { get; set; }
		public string Notes { get; set; }
		public DateTime Created_at { get; set; }
	}
}

