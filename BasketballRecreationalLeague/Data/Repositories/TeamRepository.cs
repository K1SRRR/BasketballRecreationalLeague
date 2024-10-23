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
    public class TeamRepository
    {
        public static TeamRepository GetInstance()
        {
            return App._serviceProvider.GetRequiredService<TeamRepository>();
        }
        public TeamRepository() { }
        public List<Team> GetAll()
        {
            List<Team> teams = new List<Team>();
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT \"ID\", \"Name\", \"YearOfEstablishment\" FROM \"Team\";", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teams.Add(new Team
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                YearOfEstablishment = reader.GetInt32(2),
                            });
                        }
                    }
                }
            }
            return teams;
        }
        public List<Team> SearchByName(string searchText)
        {
            List<Team> teams = new List<Team>();
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT \"ID\", \"Name\", \"YearOfEstablishment\" FROM \"Team\" WHERE \"Name\" ILIKE '%' || @searchText || '%';", connection))
                {
                    command.Parameters.AddWithValue("@searchText", searchText);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            teams.Add(CreateInstance(reader));
                    }
                }
            }
            return teams;
        }
        public Team Register(Team team)
        {
            //PROVERA ZA TIM SA ISTIM IMENOM
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand(
                    "INSERT INTO \"Team\" (\"Name\", \"YearOfEstablishment\") " +
                    "VALUES (@Name, @YearOfEstablishment)", connection))
                {
                    command.Parameters.AddWithValue("@Name", team.Name);
                    command.Parameters.AddWithValue("@YearOfEstablishment", team.YearOfEstablishment);

                    int rowsAffected = command.ExecuteNonQuery();
                    if(rowsAffected > 0)
                        return GetByName(team.Name);
                }
            }
            return null;
        }
        public Team GetByName(string teamName)
        {
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT \"ID\", \"Name\", \"YearOfEstablishment\" FROM \"Team\" WHERE \"Name\" = @Name;", connection))
                {
                    command.Parameters.AddWithValue("@Name", teamName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return CreateInstance(reader);
                    }
                }
            }
            return null;
        }

        private Team CreateInstance(NpgsqlDataReader reader)
        {
            return new Team
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                YearOfEstablishment = reader.GetInt32(2)
            };
        }

    }
}
