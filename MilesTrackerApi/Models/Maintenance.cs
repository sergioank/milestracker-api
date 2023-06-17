using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilesTrackerApi.Models
{
	public class Maintenance
	{
		[Key]
		public int Maintenance_Id { get; set; }

		[ForeignKey("Vehicle")]
		public int Vehicle_Id { get; set; }
		public Vehicle Vehicle { get; set; }

		public string Type { get; set; }
		public DateTime Date { get; set; }
		public float Cost { get; set; }
		public string Notes { get; set; }
		public DateTime Created_at { get; set; }
	}
}

