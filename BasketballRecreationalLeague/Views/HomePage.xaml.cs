using BasketballRecreationalLeague.Controllers;
using BasketballRecreationalLeague.DTO;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            LoadCurrentLeagues(); //includes loading Teams for A league of the current year
        }
        private void LoadTeams(int leagueId)
        {
            List<TeamLeagueDTO> teamLeagueDTOs = LeagueController.GetInstance().GetAllTeams(leagueId);
            if (teamLeagueDTOs != null && teamLeagueDTOs.Count > 0)
                LeagueTeamsDataGrid.ItemsSource = teamLeagueDTOs;
            else
                LeagueTeamsDataGrid.ItemsSource = null;
        }
        private void LoadCurrentLeagues()
        {
            List<LeagueDTO> LeagueDTOs = LeagueController.GetInstance().GetAllCurrent();
            LeagueGradeComboBox.ItemsSource = LeagueDTOs;
            foreach (var leagueDTO in LeagueDTOs)
                if (leagueDTO.Grade.Trim() == "A")
                {
                    LeagueGradeComboBox.SelectedItem = leagueDTO;
                    LoadTeams(leagueDTO.Id);
                }
        }

        private void LeagueSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LeagueGradeComboBox.SelectedItem is LeagueDTO selectedLeague && selectedLeague != null)
            {
                LoadTeams(selectedLeague.Id);
            }
        }
    }
}
