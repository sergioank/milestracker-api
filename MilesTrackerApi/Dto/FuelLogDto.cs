using System;
namespace MilesTrackerApi.Dto
{
    public class FuelLogDto
    {
        public int Fuel_log_id { get; set; }
        public int Vehicle_id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public float Cost_per_unit { get; set; }
        public float Total_cost { get; set; }
        public int Odometer_reading { get; set; }
        public string Notes { get; set; }
    }

}