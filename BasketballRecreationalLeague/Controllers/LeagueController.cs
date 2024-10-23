using BasketballRecreationalLeague.DTO;
using BasketballRecreationalLeague.Models;
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
            var teamLeagues = LeagueService.GetInstance().GetAllTeams(leagueId);
            var teamLeagueDTOs = new List<TeamLeagueDTO>();
            foreach (var teamLeague in teamLeagues)
                teamLeagueDTOs.Add(ConvertTeamLeagueToDTO(teamLeague));
            return teamLeagueDTOs;
            //return ConvertTeamLeagueToDTO(teamLeagues);
        }
        public List<LeagueDTO> GetAll()
        {
            var leagues = LeagueService.GetInstance().GetAll();
            var leagueDTOs = new List<LeagueDTO>();
            foreach (var league in leagues)
                leagueDTOs.Add(ConvertLeagueToDTO(league));
            return leagueDTOs;
        }
        public List<LeagueDTO> GetAllCurrent()
        {
            var leagues = LeagueService.GetInstance().GetAllCurrent();
            var leagueDTOs = new List<LeagueDTO>();
            foreach (var league in leagues)
                leagueDTOs.Add(ConvertLeagueToDTO(league));
            return leagueDTOs;
            //return ConvertLeagueToDTO(leagues);
        }

        private LeagueDTO ConvertLeagueToDTO(League league)
        {
            return new LeagueDTO
            {
                Id = league.Id,
                Grade = league.Grade,
                Season = league.Season
            };
        }
        private TeamLeagueDTO ConvertTeamLeagueToDTO(TeamLeague teamLeague)
        {
            return new TeamLeagueDTO
            {
                Id = teamLeague.Id,
                Name = teamLeague.Name,
                Wins = teamLeague.Wins,
                Loses = teamLeague.Loses,
                PointsGiven = teamLeague.PointsGiven,
                PointsReceived = teamLeague.PointsReceived,
                PointsDifference = teamLeague.PointsDifference
            };
        }

    }
}
