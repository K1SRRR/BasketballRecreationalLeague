using BasketballRecreationalLeague.Models;
using Microsoft.Extensions.DependencyInjection;
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
        public static PlayerRepository GetInstance()
        {
            return App._serviceProvider.GetRequiredService<PlayerRepository>();
        }
        private List<Player> _players;
        public PlayerRepository() { }

        public List<Player> GetAll()
        {
            List<Player> players = new List<Player>();
            using (var connection = App.GetConnection())
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
                            FirstName = reader.GetString(1)
                        });
                    }
                }
            }
            return players;
        }
        public Player GetById(int id)
        {
            Player player = null;
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM \"Player\" WHERE ID = @id", connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            player = new Player
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return player;
        }

        public void Create(Player player)
        {
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("INSERT INTO \"Player\" (FirstName) VALUES (@firstName)", connection))
                {
                    command.Parameters.AddWithValue("firstName", player.FirstName);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdatePlayer(Player player)
        {
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("UPDATE \"Player\" SET FirstName = @firstName WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("firstName", player.FirstName);
                    command.Parameters.AddWithValue("id", player.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePlayer(int id)
        {
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("DELETE FROM \"Player\" WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
