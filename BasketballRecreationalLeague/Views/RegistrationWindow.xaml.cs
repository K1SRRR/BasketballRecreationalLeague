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
using System.Windows.Shapes;

namespace BasketballRecreationalLeague.Views
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public INotificationManager notificationManager = App.GetNotificationManager();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            bool isVisitorChecked = VisitorRadioButton.IsChecked ?? false;
            bool isPlayerChecked = PlayerRadioButton.IsChecked ?? false;

            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password) ||
                string.IsNullOrWhiteSpace(confirmPassword.Password) ||
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                !BirthDayDatePicker.SelectedDate.HasValue ||
                (!isVisitorChecked && !isPlayerChecked))
            {
                notificationManager.Show("Warning", "All fields must be filled!", NotificationType.Warning);
                return;
            }
            if (txtPassword.Password != confirmPassword.Password)
            {
                notificationManager.Show("Warning", "Passwords are not the same!", NotificationType.Warning);
                return;
            }

            var userDTO = new UserDTO
            {
                Username = UsernameTextBox.Text,
                Password = txtPassword.Password,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                BirthDay = BirthDayDatePicker.SelectedDate.HasValue
                            ? BirthDayDatePicker.SelectedDate.Value
                            : DateTime.MinValue,
                UserType = isVisitorChecked ? UserType.Visitor : UserType.Player
            };

            if(UserController.GetInstance().Register(userDTO))
            {
                notificationManager.Show("Success", "User successfully registered!", NotificationType.Success);
                Close();
            }
            else
            {
                notificationManager.Show("Error", "Username already exists!", NotificationType.Error);
                Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
