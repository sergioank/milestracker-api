using System;
namespace MilesTrackerApi.Dto
{
	public class VehicleDto
	{
        public int Vehicle_Id { get; set; }
        public int User_Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string License_Plate { get; set; }
        public int Odometer { get; set; }
    }
}

