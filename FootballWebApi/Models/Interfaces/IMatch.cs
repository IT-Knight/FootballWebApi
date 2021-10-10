using System;

namespace FootballWebApi.Models.Interfaces
{
    public interface IMatch
    {
        MatchLocation City { get; set; }
        DateTime DateOfMatch { get; set; }
        int Id { get; set; }
        Team Team1 { get; set; }
        int Team1Score { get; set; }
        Team Team2 { get; set; }
        int Team2Score { get; set; }
        string WinnerTeam { get; set; }
    }
}