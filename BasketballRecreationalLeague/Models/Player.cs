using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Models
{
    public class Player : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private DateTime birthDay { get; set; }
        private string phoneNumber { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged(nameof(id));
                }
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
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
            get
            {
                return lastName;
            }
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
            get
            {
                return birthDay;
            }
            set
            {
                if (value != birthDay)
                {
                    birthDay = value;
                    OnPropertyChanged(nameof(birthDay));
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    OnPropertyChanged(nameof(phoneNumber));
                }
            }
        }
    }
}
