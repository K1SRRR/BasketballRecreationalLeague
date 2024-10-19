using BasketballRecreationalLeague.DTO;
using BasketballRecreationalLeague.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Controllers
{
    public class LeagueController
    {
        public static LeagueController GetInstance()
        {
            return App._serviceProvider.GetRequiredService<LeagueController>();
        }
        public LeagueController() { }
        public List<TeamLeagueDTO> GetAllTeams(int leagueId)
        {
            var teamsLeague = LeagueService.GetInstance().GetAllTeams(leagueId);
            var teamLeagueDTOs = new List<TeamLeagueDTO>();
            foreach(var teamLeague in teamsLeague)
            {
                teamLeagueDTOs.Add(new TeamLeagueDTO
                {
                    Id = teamLeague.Id,
                    Name = teamLeague.Name,
                    Wins = teamLeague.Wins,
                    Loses = teamLeague.Loses,
                    PointsGiven = teamLeague.PointsGiven,
                    PointsReceived = teamLeague.PointsReceived,
                    PointsDifference = teamLeague.PointsDifference
                });
            }
            return teamLeagueDTOs;
        }
    }
}
