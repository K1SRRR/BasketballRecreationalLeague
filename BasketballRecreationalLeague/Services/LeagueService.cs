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
    public class LeagueService
    {
        public static LeagueService GetInstance()
        {
            return App._serviceProvider.GetRequiredService<LeagueService>();
        }
        public LeagueService() { }
        public List<TeamLeague> GetAllTeams(int leagueId)
        {
            return LeagueRepository.GetInstance().GetAllTeams(leagueId);
        }
    }
}
