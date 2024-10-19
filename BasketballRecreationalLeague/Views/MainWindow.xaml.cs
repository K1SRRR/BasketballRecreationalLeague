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
        public MainWindow()
        {
            InitializeComponent();
            LoadPlayers();
        }
        private void LoadPlayers()
        {
            List<PlayerDTO> players = PlayerController.GetInstance().GetAll();
            PlayersDataGrid.ItemsSource = players;
        }
    }
}
