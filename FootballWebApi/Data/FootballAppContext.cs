using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballWebApi.Helpers;
using FootballWebApi.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;


namespace FootballWebApi.Data
{
    public class FootballAppContext: DbContext
    {
        public FootballAppContext(DbContextOptions<FootballAppContext> options)
            : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MatchLocation> MatchLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "admin",
                Password = PasswordHasher.Hash("321"),
                Role = "Admin"
            });

            modelBuilder.Entity<Team>().HasData(new Team[] 
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
            });


            modelBuilder.Entity<MatchLocation>().HasData(new MatchLocation[] 
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
            });


            // Seed Matches *thinking*...
            // it's a problem to SeedData with Foreign Key from here




        }
    }


}
