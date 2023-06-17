using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilesTrackerApi.Models
{
	public class Trip
	{
		[Key]
		public int Trip_Id { get; set; }

		[ForeignKey("User")]
		public int User_Id { get; set; }
		public User User { get; set; }

		[ForeignKey("Vehicle")]
		public int Vehicle_Id { get; set; }
		public Vehicle Vehicle { get; set; }

		public string Start_Location { get; set; }
		public string End_Location { get; set; }
		public int Distance { get; set; }
		public string Notes { get; set; }
		public DateTime Created_At { get; set; }
	}
}

