using BasketballRecreationalLeague.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
        //public List<TeamDTO> GetByLeagueId(int leagueId)
        //{

        //}
    }
}
