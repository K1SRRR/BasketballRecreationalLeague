using BasketballRecreationalLeague.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Data.Repositories
{
    public class PlayerRepository
    {
        private Database _database;

        public PlayerRepository()
        {
            _database = new Database();
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();
            using (var connection = _database.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM \"Player\"", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(new Player
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
            return players;
        }
    }
}
