using BasketballRecreationalLeague.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.DTO
{
    public class UserDTO : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private DateTime birthDay { get; set; }
        private UserType userType { get; set; }
        public UserDTO() { }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }
        public UserDTO(int id, string username, string password, string firstName, string lastName, DateTime birthDay, UserType userType)
        {
            Id = id;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            UserType = userType;
        }
        public int Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged(nameof(id));
                }
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                if (value != username)
                {
                    username = value;
                    OnPropertyChanged(nameof(username));
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged(nameof(password));
                }
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(firstName));
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(lastName));
                }
            }
        }
        public DateTime BirthDay
        {
            get { return birthDay; }
            set
            {
                if (value != birthDay)
                {
                    birthDay = value;
                    OnPropertyChanged(nameof(birthDay));
                }
            }
        }
        public UserType UserType
        {
            get { return userType; }
            set
            {
                if (value != userType)
                {
                    userType = value;
                    OnPropertyChanged(nameof(userType));
                    OnPropertyChanged(nameof(UserTypeString));
                }
            }
        }
        public string UserTypeString
        {
            get { return UserType.ToString(); }
            set
            {
                if (Enum.TryParse(value, out UserType parsedUserType) && parsedUserType != userType)
                {
                    OnPropertyChanged(nameof(UserTypeString));
                }
            }
        }


    }
}
