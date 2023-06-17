using System;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Dto
{
	public class UserDto
	{
        public int User_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Setting Setting { get; set; }
    }
}

