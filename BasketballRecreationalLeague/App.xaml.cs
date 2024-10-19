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
             string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=super;Database=Kosarkaska rekreativna liga;";

            _services = new ServiceCollection();
            _services.AddSingleton<NpgsqlConnection>(provider => new NpgsqlConnection(connectionString));
            _services.AddSingleton<PlayerRepository>();
            _services.AddSingleton<PlayerService>();
            _services.AddSingleton<PlayerController>();

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
            return _serviceProvider.GetRequiredService<NpgsqlConnection>();
        }
    }
}
