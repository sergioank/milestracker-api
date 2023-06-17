using System;
using System.ComponentModel.DataAnnotations;

namespace MilesTrackerApi.Models
{
	public class Car
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Maker { get; set; }
		public string Model { get; set; }
		public int MPG { get; set; }
		public int Year { get; set; }
		public string Color { get; set; }
	}
}

