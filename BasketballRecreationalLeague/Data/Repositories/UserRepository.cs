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
    public class UserRepository
    {
        public static UserRepository GetInstance()
        {
            return App._serviceProvider.GetRequiredService<UserRepository>();
        }
        public UserRepository() { }
        public bool Register(User user)
        {
            if (GetByUsername(user.Username) != null) 
                return false;

            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("INSERT INTO \"User\" (\"Username\", \"Password\", \"FirstName\", \"LastName\", \"BirthDay\", \"UserType\") " +
                                                       "VALUES (@Username, @Password, @FirstName, @LastName, @BirthDay, @UserType);", connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@BirthDay", user.BirthDay);
                    command.Parameters.AddWithValue("@UserType", user.UserType.ToString());

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT \"ID\", \"Username\", \"Password\", \"FirstName\", \"LastName\", \"BirthDay\", \"UserType\" " +
                                                       "FROM \"User\";", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                            users.Add(CreateUserInstance(reader));
                    }
                }
            }
            return users;
        }

        public User GetByUsername(string username)
        {
            using (var connection = App.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT \"ID\", \"Username\", \"Password\", \"FirstName\", \"LastName\", \"BirthDay\", \"UserType\" " +
                                                       "FROM \"User\" " +
                                                       "WHERE \"Username\" = @Username;", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return CreateUserInstance(reader);
                    }
                }
            }
            return null;
        }

        private User CreateUserInstance(NpgsqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                Password = reader.GetString(2),
                FirstName = reader.GetString(3),
                LastName = reader.GetString(4),
                BirthDay = reader.GetDateTime(5),
                UserType = (UserType)Enum.Parse(typeof(UserType), reader.GetString(6))
            };
        }
    }
}
