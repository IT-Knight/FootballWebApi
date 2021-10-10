using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballWebApi.Data;
using FootballWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballWebApi.Helpers
{
    public class MatchBuilder
    {
        private Random r = new Random();
        private List<int> TeamIds = teamsList.Select(x => x.Id).ToList();
        private FootballAppContext _context;
        public MatchBuilder(FootballAppContext context)
        {
            _context = context;
        }

        public async Task<Match> BuildMatch()
        {
            var match = new Match();
            int randomIndex;

            List<int> teamsIndexes = new List<int>(TeamIds);
            var teamIndexesLenght = teamsIndexes.Count;

            randomIndex = r.Next(teamIndexesLenght);
            var team1Id = teamsIndexes[randomIndex]; 
            match.Team1 = await _context.Teams.FindAsync(team1Id);
            
            teamsIndexes.Remove(randomIndex);
            
            randomIndex = r.Next(teamIndexesLenght - 1);
            var team2Id = teamsIndexes[randomIndex];
            match.Team2 = await _context.Teams.FindAsync(team2Id);

            match.City = await _context.MatchLocations.FindAsync(r.Next(1, matchesLocations.Count));

            match.Id = 0;
            match.Team1Score = r.Next(1, 9); match.Team2Score = r.Next(1, 9);
            match.WinnerTeam = match.Team1Score > match.Team2Score ? match.Team1.Name : (match.Team1Score == match.Team2Score) ? "Draw" : match.Team2.Name;
            match.DateOfMatch = RandomDay();

            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return match;
        }

        #region #Failed Region
        // doesn't work
        // public Match[] SeedRandomMatches()
        // {
        //     var match = new Match();
        //     int randomIndex = 0;
        //     List<Match> matchesList = new();
        //     List<int> teams;
        //
        //     for (int i = 1; i <= 31; i++)
        //     {
        //         teams = new List<int>(TeamIds);
        //         match.Id = 0;
        //         randomIndex = r.Next(teams.Count);
        //         
        //         match.Team1 = new Team() { Name = teamsList[randomIndex].Name };
        //         teams.Remove(randomIndex);
        //         randomIndex = r.Next(teams.Count);
        //         match.Team2 = new Team() { Name = teamsList[randomIndex].Name };
        //         match.Team1Score = r.Next(0, 9);
        //         match.Team2Score = r.Next(0, 9);
        //         match.WinnerTeam = (match.Team1Score > match.Team2Score) ? match.Team1.Name : (match.Team1Score == match.Team2Score) ? "Draw" : match.Team2.Name;
        //         match.DateOfMatch = RandomDay();
        //         match.City = new MatchLocation() { Location = matchesLocations[randomIndex].Location };
        //
        //         matchesList.Add(match);
        //     }
        //     return matchesList.ToArray();
        // }
        #endregion Region

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }

        private static List<Team> teamsList = new List<Team>
        {
                new Team { Id=1, Name = "Atlanta Falcons"},
                new Team { Id=2, Name = "Arizona Cardinals"},
                new Team { Id=3, Name = "Carolina Panthers"},
                new Team { Id=4, Name = "Chicago Bears"},
                new Team { Id=5, Name = "Dallas Cowboys"},
                new Team { Id=6, Name = "Detroit Lions"},
                new Team { Id=7, Name = "Green Bay Packers"},
                new Team { Id=8, Name = "Los Angeles Rams"},
                new Team { Id=9, Name = "Minnesota Vikings"},
                new Team { Id=10, Name = "New Orleans Saints"},
                new Team { Id=11, Name = "New York Giants"},
                new Team { Id=12, Name = "Philadelphia Eagles"},
                new Team { Id=13, Name = "San Francisco 49ers"},
                new Team { Id=14, Name = "Seattle Seahawks"},
                new Team { Id=15, Name = "Tampa Bay Buccaneers"},
                new Team { Id=16, Name = "Washington Football Team"},
                new Team { Id=17, Name = "Tennessee Titans"},
                new Team { Id=18, Name = "Pittsburgh Steelers"}
        };

        private static List<MatchLocation> matchesLocations = new List<MatchLocation>()
        {
                new MatchLocation { Id=1, Location = "Liverpool, England" },
                new MatchLocation { Id=2, Location = "Manchester, England" },
                new MatchLocation { Id=3, Location = "Buenos Aires, Argentina" },
                new MatchLocation { Id=4, Location = "Madrid, Spain" },
                new MatchLocation { Id=5, Location = "Mexico City, Mexico" },
                new MatchLocation { Id=6, Location = "London, England" },
                new MatchLocation { Id=7, Location = "Milan, Italy" },
                new MatchLocation { Id=8, Location = "Barcelona, Spain" },
                new MatchLocation { Id=9, Location = "Rio De Janeiro, Brazil" },
                new MatchLocation { Id=10, Location = "Mexico City, Mexico" },
                new MatchLocation { Id=11, Location = "Glasgow, Scotland" },
                new MatchLocation { Id=12, Location = "Rio de Janeiro, Brazil" },
                new MatchLocation { Id=13, Location = "Rome, Italy" },
                new MatchLocation { Id=14, Location = "Moscow, Russia" },
                new MatchLocation { Id=15, Location = "Lisbon, Portugal" },
                new MatchLocation { Id=16, Location = "Rome, Italy" },
                new MatchLocation { Id=17, Location = "Athens, Greece" },
                new MatchLocation { Id=18, Location = "Madrid, Spain" },
                new MatchLocation { Id=19, Location = "Rome, Italy" }
        };

    }
}
