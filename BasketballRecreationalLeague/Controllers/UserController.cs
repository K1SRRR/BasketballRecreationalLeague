using BasketballRecreationalLeague.DTO;
using BasketballRecreationalLeague.Models;
using BasketballRecreationalLeague.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Controllers
{
    public class UserController
    {
        public static UserController GetInstance()
        {
            return App._serviceProvider.GetRequiredService<UserController>();
        }
        public UserController() { }
        
        public bool Register(UserDTO userDTO)
        {
            User user = ConvertDTOToUser(userDTO);
            return UserService.GetInstance().Register(user);
        }
        public UserDTO LogIn(string username, string plainPassword)
        {
            User user = UserService.GetInstance().Login(username, plainPassword);
            if (user == null) 
                return null;
            return ConvertUserToDTO(user);
        }

        private User ConvertDTOToUser(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                BirthDay = userDTO.BirthDay,
                UserType = userDTO.UserType
            };
        }
        private UserDTO ConvertUserToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDay = user.BirthDay,
                UserType = user.UserType
            };
        }
    }
}
