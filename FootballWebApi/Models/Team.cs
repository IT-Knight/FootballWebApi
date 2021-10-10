using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballWebApi.Models
{
    public class Team
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class TeamDto
    {
        public string Name { get; set; }
        
    }
}
