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
    public class PlayerService
    {
        public static PlayerService GetInstance()
        {
            return App._serviceProvider.GetRequiredService<PlayerService>();
        }
        public PlayerService() { }
        public List<Player> GetAll()
        {
            return PlayerRepository.GetInstance().GetAll();
        }
    }
}
