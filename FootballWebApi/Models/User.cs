using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballWebApi.Models
{

    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public string Role { get; set; } = "User";
    }


    public class UserDto
    {
        public string Username { get; set; }
        public string Role { get; set; }
        
    }
}
