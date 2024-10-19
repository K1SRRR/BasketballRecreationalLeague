using BasketballRecreationalLeague.Data.Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasketballRecreationalLeague
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
            PlayerRepository playerRepository = new PlayerRepository();
            List<Player> players = playerRepository.GetAllPlayers();
            PlayersDataGrid.ItemsSource = players; // Povezivanje podataka sa DataGrid
        }
    }
}
