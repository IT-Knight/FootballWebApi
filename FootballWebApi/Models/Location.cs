using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballWebApi.Models
{
    public class MatchLocation
    {
        public int Id { get; set; }
        public string Location { get; set; }
    }

    public class MatchLocationDTO: MatchLocation
    {
        public new string Location { get; set; }
    }
}
