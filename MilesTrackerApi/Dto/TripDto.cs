using System;
namespace MilesTrackerApi.Dto
{
	public class TripDto
	{
        public int Trip_Id { get; set; }
        public int User_Id { get; set; }
        public int Vehicle_Id { get; set; }
        public string Start_Location { get; set; }
        public string End_Location { get; set; }
        public int Distance { get; set; }
        public string Notes { get; set; }
    }
}

