using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FootballWebApi.Models.Interfaces;

namespace FootballWebApi.Models
{
    public class Match : IMatch
    {
        public int Id { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Score { get; set; } 
        public int Team2Score { get; set; }
        public string WinnerTeam { get; set; }
        public MatchLocation City { get; set; }
        public DateTime DateOfMatch { get; set; }

        // public Match()
        // {
        //     WinnerTeam = Team1Score > Team2Score ? Team1.Name : (Team1Score == Team2Score) ? "Draw" : Team2.Name;
        // }
        
    }

    public class MatchDto
    {         
        public int Id { get; set; }
        public string Team1 { get; set; }
        public  string Team2 { get; set; }
        public  int Team1Score { get; set; }
        public  int Team2Score { get; set; }
        public string WinnerTeam { get; set; }
        public string MatchKLocation { get; set; }
        public string DateOfMatch { get; set; }

        

    }
}
