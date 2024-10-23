using BasketballRecreationalLeague.DTO;
using BasketballRecreationalLeague.Models;
using BasketballRecreationalLeague.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Controllers
{
    public class TeamController
    {
        public static TeamController GetInstance()
        {
            return App._serviceProvider.GetRequiredService<TeamController>();
        }
        public TeamController() { }
        public ObservableCollection<TeamDTO> GetAll()
        {
            var teams = TeamService.GetInstance().GetAll();
            var teamDTOs = new ObservableCollection<TeamDTO>();
            foreach (var team in teams)
                teamDTOs.Add(ConvertTeamToDTO(team));
            return teamDTOs;
        }
        public ObservableCollection<TeamDTO> SearchByName(string searchText)
        {
            var teams = TeamService.GetInstance().SearchByName(searchText);
            var teamDTOs = new ObservableCollection<TeamDTO>();
            foreach (var team in teams)
                teamDTOs.Add(ConvertTeamToDTO(team));
            return teamDTOs;
        }
        public TeamDTO Register(TeamDTO teamDTO)
        {
            Team team = ConvertDTOToTeam(teamDTO);
            return ConvertTeamToDTO(TeamService.GetInstance().Register(team));
        }

        public TeamDTO ConvertTeamToDTO(Team team)
        {
            return new TeamDTO
            {
                Id = team.Id,
                Name = team.Name,
                YearOfEstablishment = team.YearOfEstablishment
            };
        }
        public Team ConvertDTOToTeam(TeamDTO teamDTO)
        {
            return new Team
            {
                Id = teamDTO.Id,
                Name = teamDTO.Name,
                YearOfEstablishment = teamDTO.YearOfEstablishment
            };
        }
    }
}
