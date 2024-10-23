using BasketballRecreationalLeague.Controllers;
using BasketballRecreationalLeague.DTO;
using BasketballRecreationalLeague.Models;
using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasketballRecreationalLeague.Views
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserDTO UserDTO { get; set; }
        public INotificationManager notificationManager = App.GetNotificationManager();
        MainWindow MainWindow { get; set; }
        public UserPage(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            UserDTO = mainWindow.UserDTO;
            InitializeComponent();
            DataContext = this;

            if(UserDTO.UserType == UserType.Unlogged)
            {
                LoggedUserGrid.Visibility = Visibility.Collapsed;
                UnloggedUserGrid.Visibility = Visibility.Visible;
                RefereeRegGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                LoggedUserGrid.Visibility = Visibility.Visible;
                UnloggedUserGrid.Visibility = Visibility.Collapsed;
                if (UserDTO.UserType == UserType.Admin)
                    RefereeRegGrid.Visibility = Visibility.Visible;
            }
        }

        private void RegisterViewClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            registrationWindow.Focus();
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                notificationManager.Show("Warning", "All fields must be filled!", NotificationType.Warning);
                return;
            }

            UserDTO userDTO = UserController.GetInstance().LogIn(UsernameTextBox.Text, txtPassword.Password);
            if (userDTO != null)
            {
                MainWindow.UserDTO.Id = userDTO.Id;
                MainWindow.UserDTO.Username = userDTO.Username;
                MainWindow.UserDTO.Password = userDTO.Password;
                MainWindow.UserDTO.FirstName = userDTO.FirstName;
                MainWindow.UserDTO.LastName = userDTO.LastName;
                MainWindow.UserDTO.BirthDay = userDTO.BirthDay;
                MainWindow.UserDTO.UserType = userDTO.UserType;
                UserDTO = MainWindow.UserDTO;

                notificationManager.Show("Success", "Successfully logged in!", NotificationType.Success);
                LoggedUserGrid.Visibility = Visibility.Visible;
                UnloggedUserGrid.Visibility = Visibility.Collapsed;
                if (UserDTO.UserType == UserType.Admin) 
                    RefereeRegGrid.Visibility = Visibility.Visible;
            }
            else
            {
                notificationManager.Show("Error", "Wrong username or password!", NotificationType.Error);
            }
        }

        private void LogOutClick(object sender, RoutedEventArgs e)
        {
            MainWindow.UserDTO.Id = 0;
            MainWindow.UserDTO.Username = "Unlogged";
            MainWindow.UserDTO.Password = "";
            MainWindow.UserDTO.FirstName = "";
            MainWindow.UserDTO.LastName = "";
            MainWindow.UserDTO.BirthDay = DateTime.Now;
            MainWindow.UserDTO.UserType = UserType.Unlogged;
            LoggedUserGrid.Visibility = Visibility.Collapsed;
            UnloggedUserGrid.Visibility = Visibility.Visible;
            RefereeRegGrid.Visibility = Visibility.Collapsed;
        }

        private void RefereeRegisterClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RefereeRegUsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(RefereeRegtxtPassword.Password) ||
                string.IsNullOrWhiteSpace(RefereeRegconfirmPassword.Password) ||
                string.IsNullOrWhiteSpace(RefereeRegFirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(RefereeRegLastNameTextBox.Text) ||
                !RefereeRegBirthDayDatePicker.SelectedDate.HasValue)
            {
                notificationManager.Show("Warning", "All fields must be filled!", NotificationType.Warning);
                return;
            }
            if (RefereeRegtxtPassword.Password != RefereeRegconfirmPassword.Password)
            {
                notificationManager.Show("Warning", "Passwords are not the same!", NotificationType.Warning);
                return;
            }

            var userDTO = new UserDTO
            {
                Username = RefereeRegUsernameTextBox.Text,
                Password = RefereeRegtxtPassword.Password,
                FirstName = RefereeRegFirstNameTextBox.Text,
                LastName = RefereeRegLastNameTextBox.Text,
                BirthDay = RefereeRegBirthDayDatePicker.SelectedDate.HasValue
                            ? RefereeRegBirthDayDatePicker.SelectedDate.Value
                            : DateTime.MinValue,
                UserType = UserType.Referee
            };

            if (UserController.GetInstance().Register(userDTO))
            {
                notificationManager.Show("Success", "User successfully registered!", NotificationType.Success);
                RefereeRegUsernameTextBox.Text = string.Empty;
                RefereeRegtxtPassword.Password = string.Empty;
                RefereeRegconfirmPassword.Password = string.Empty;
                RefereeRegFirstNameTextBox.Text = string.Empty;
                RefereeRegLastNameTextBox.Text = string.Empty;
                RefereeRegBirthDayDatePicker.SelectedDate = null;
            }
            else
            {
                notificationManager.Show("Error", "Username already exists!", NotificationType.Error);
            }
        }
    }
}
