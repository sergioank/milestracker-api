using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MilesTrackerApi.Models
{
	public class Setting
	{
		[Key]
		public int Setting_Id { get; set; }


		public int User_Id { get; set; }
		
		public string Distance_Unit { get; set; }
		public string Fuel_Consumption_Unit { get; set; }
		public DateTime Created_At { get; set; }
	}
}

