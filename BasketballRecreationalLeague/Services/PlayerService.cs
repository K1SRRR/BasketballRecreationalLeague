using BasketballRecreationalLeague.Data.Repositories;
using BasketballRecreationalLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Services
{
    public class PlayerService
    {
        private PlayerRepository _playerRepository;

        public PlayerService()
        {
            _playerRepository = new PlayerRepository();
        }
        public List<Player> GetPlayers()
        {
            return _playerRepository.GetAllPlayers();
        }
    }
}
