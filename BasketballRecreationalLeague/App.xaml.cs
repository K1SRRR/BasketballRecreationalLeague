using BasketballRecreationalLeague.Controllers;
using BasketballRecreationalLeague.Data;
using BasketballRecreationalLeague.Data.Repositories;
using BasketballRecreationalLeague.Models;
using BasketballRecreationalLeague.Services;
using BasketballRecreationalLeague.Views;
using Microsoft.Extensions.DependencyInjection;
using Notification.Wpf;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BasketballRecreationalLeague
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceCollection _services;
        public static IServiceProvider _serviceProvider;

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {

            _services = new ServiceCollection();
            _services.AddSingleton<PlayerRepository>();
            _services.AddSingleton<PlayerService>();
            _services.AddSingleton<PlayerController>();
            _services.AddSingleton<LeagueRepository>();
            _services.AddSingleton<LeagueService>();
            _services.AddSingleton<LeagueController>();
            _services.AddSingleton<UserRepository>();
            _services.AddSingleton<UserService>();
            _services.AddSingleton<UserController>();
            _services.AddSingleton<TeamRepository>();
            _services.AddSingleton<TeamService>();
            _services.AddSingleton<TeamController>();
            _services.AddSingleton<RefereeRepository>();
            _services.AddSingleton<INotificationManager, NotificationManager>();


            _serviceProvider = _services.BuildServiceProvider();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        public static INotificationManager GetNotificationManager()
        {
            return _serviceProvider.GetRequiredService<INotificationManager>();
        }
        public static NpgsqlConnection GetConnection()
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=super;Database=Kosarkaska rekreativna liga;";
            return new NpgsqlConnection(connectionString);
        }
    }
}
