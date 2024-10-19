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
    public class PlayerController
    {
        public static PlayerController GetInstance()
        {
            return App._serviceProvider.GetRequiredService<PlayerController>();
        }
        public PlayerController() { }
        public List<PlayerDTO> GetAll()
        {
            var players = PlayerService.GetInstance().GetAll();
            var playerDTOs = new List<PlayerDTO>();

            foreach (var player in players)
            {
                playerDTOs.Add(new PlayerDTO
                {
                    Id = player.Id,
                    FirstName = player.FirstName
                });
            }

            return playerDTOs;
        }
    }
}
