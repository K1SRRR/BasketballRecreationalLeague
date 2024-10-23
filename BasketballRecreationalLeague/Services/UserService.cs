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
    public class UserService
    {
        public static UserService GetInstance()
        {
            return App._serviceProvider.GetRequiredService<UserService>();
        }
        public UserService() { }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
        }
        public bool Register(User user)
        {
            user.Password = HashPassword(user.Password);
            bool isUserRegistered = UserRepository.GetInstance().Register(user);
            bool isPlayerRegistered = true, isRefereeRegistered = true;
            //if (user.UserType == UserType.Player)
            //{
            //    isPlayerRegistered = PlayerRepository.GetInstance().Add(user.Id);
            //}
            //else if(user.UserType == UserType.Referee)
            //{
            //    isRefereeRegistered = RefereeRepository.GetInstance().Add(user.Id);
            //}
            return isUserRegistered && isPlayerRegistered && isRefereeRegistered;
        }
        public User Login(string username, string plainPassword)
        {
            User user = UserRepository.GetInstance().GetByUsername(username);
            if (user == null) return null;

            if(VerifyPassword(plainPassword, user.Password))
                return user;
            return null;
        }
    }
}
