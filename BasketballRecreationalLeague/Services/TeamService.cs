using BasketballRecreationalLeague.Data.Repositories;
using BasketballRecreationalLeague.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Services
{
    public class TeamService
    {
        public static TeamService GetInstance()
        {
            return App._serviceProvider.GetRequiredService<TeamService>();
        }
        public TeamService() { }
        public List<Team> GetAll()
        {
            return TeamRepository.GetInstance().GetAll();
        }
        public List<Team> SearchByName(string searchText)
        {
            return TeamRepository.GetInstance().SearchByName(searchText);
        }
        public Team Register(Team team)
        {
            return TeamRepository.GetInstance().Register(team);
        }
    }
}
