using BasketballRecreationalLeague.Controllers;
using BasketballRecreationalLeague.DTO;
using Microsoft.Win32;
using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TeamsPage.xaml
    /// </summary>
    public partial class TeamsPage : Page
    {
        public INotificationManager notificationManager = App.GetNotificationManager();
        public ObservableCollection<TeamDTO> TeamDTOs {  get; set; }
        public TeamsPage(MainWindow mainWindow)
        {
            InitializeComponent();
            TeamDTOs = new ObservableCollection<TeamDTO>(TeamController.GetInstance().GetAll());
            if (mainWindow.UserDTO.UserType != Models.UserType.Admin)
                TeamRegGrid.Visibility = Visibility.Collapsed;

            DataContext = this;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            TeamDTOs.Clear();
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                foreach(var team in TeamController.GetInstance().GetAll())
                    TeamDTOs.Add(team);
            }
            else
            {
                foreach (var team in TeamController.GetInstance().SearchByName(SearchTextBox.Text))
                    TeamDTOs.Add(team);
            }
        }

        private void RegisterTeamClick(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TeamRegNameTextBox.Text))
            {
                notificationManager.Show("Warning", "All fields must be filled!", NotificationType.Warning);
                return;
            }

            var teamDTO = new TeamDTO
            {
                Name = TeamRegNameTextBox.Text,
                YearOfEstablishment = DateTime.Now.Year
            };

            teamDTO = TeamController.GetInstance().Register(teamDTO);
            if (teamDTO != null)
            {
                TeamDTOs.Add(teamDTO);
                notificationManager.Show("Success", "Team successfully registered!", NotificationType.Success);
                TeamRegNameTextBox.Text = string.Empty;
            }
            else
            {
                notificationManager.Show("Error", "Team not registered!", NotificationType.Error);
            }
        }

        private void TeamCardClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedTeam = button.DataContext as TeamDTO;
            TeamWindow teamWindow = new TeamWindow(selectedTeam);
            teamWindow.Show();
            teamWindow.Focus();
        }

        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            //// Otvaranje File Dialoga
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image files (*.jpg, *.png)|*.jpg;*.png";

            //if (openFileDialog.ShowDialog() == true)
            //{
            //    // Učitavanje slike
            //    string selectedFileName = openFileDialog.FileName;
            //    BitmapImage bitmap = new BitmapImage(new Uri(selectedFileName));

            //    // Prikaz slike u WPF kontroli
            //    UploadedImage.Source = bitmap;

            //    // Konverzija slike u byte array za skladište
            //    byte[] imageBytes = File.ReadAllBytes(selectedFileName);

            //    // Sada možeš poslati imageBytes u skladište (npr. AWS S3)
            //    // Takođe možeš dobiti URL slike sa skladišta
            //    string imageUrl = UploadImageToS3(imageBytes);

            //    // Sačuvaj URL u bazu podataka
            //    SaveImageUrlToDatabase(imageUrl);
            //}
        }
    }
}
