using BasketballRecreationalLeague.Controllers;
using BasketballRecreationalLeague.Data.Repositories;
using BasketballRecreationalLeague.DTO;
using BasketballRecreationalLeague.Models;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserDTO UserDTO {  get; set; }
        public UserPage UserPage { get; set; }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            UserDTO = new UserDTO(0, "Logged out", "", "", "", System.DateTime.Now, UserType.Unlogged);

            UserPage = new UserPage(this);
            mainFrame.Navigate(new HomePage());
        }

        private void HallofFameClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new HallOfFamePage());
        }
        private void HomePageClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new HomePage());
        }
        private void LeaguesClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new LeaguesPage());
        }
        private void ScheduleClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SchedulePage());
        }

        private void TeamsClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new TeamsPage(this));
        }

        private void UserPageClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(UserPage);
        }
    }
}
