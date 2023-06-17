using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilesTrackerApi.Models
{
	public class User
	{
		[Key]
		public int User_Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public DateTime Created_At { get; set; }
		public DateTime Updated_At { get; set; }

		public Setting Setting { get; set; }

		public List<Trip> Trips { get; set; }
		public List<Vehicle> Vehicles { get; set; }
    }
}

