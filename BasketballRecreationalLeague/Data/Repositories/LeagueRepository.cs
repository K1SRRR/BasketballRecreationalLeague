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
    public class LeagueRepository
    {
        public static LeagueRepository GetInstance()
        {
            return App._serviceProvider.GetRequiredService<LeagueRepository>();
        }
        public LeagueRepository() { }
        public List<TeamLeague> GetAllTeams(int leagueId)
        {
            List<TeamLeague> teamsInLeague = new List<TeamLeague>();
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT t.\"ID\", t.\"Name\", " +
                    "tl.\"Wins\", tl.\"Loses\", tl.\"PointsGiven\", tl.\"PointsReceived\" " +
                    "FROM \"Team\" t JOIN \"Team_League\" tl ON t.\"ID\" = tl.\"Team_ID\" " +
                    "WHERE tl.\"League_ID\" = @LeagueID;", connection))
                {
                    command.Parameters.AddWithValue("@LeagueID", leagueId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teamsInLeague.Add(new TeamLeague
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Wins = reader.GetInt32(2),
                                Loses = reader.GetInt32(3),
                                PointsGiven = reader.GetInt32(4),
                                PointsReceived = reader.GetInt32(5),
                                PointsDifference = reader.GetInt32(4) - reader.GetInt32(5)
                            });
                        }
                    }
                }
            }
            return teamsInLeague;
        }
    }
}
