using System;
namespace MilesTrackerApi.Dto
{
	public class MaintenanceDto
	{
        public int Maintenance_Id { get; set; }
        public int Vehicle_Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public string Notes { get; set; }
    }
}

