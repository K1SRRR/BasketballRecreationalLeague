﻿using BasketballRecreationalLeague.DTO;
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
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        public TeamDTO TeamDTO { get; set; }
        public TeamWindow(TeamDTO teamDTO)
        {
            InitializeComponent();
            TeamDTO = teamDTO;
            DataContext = this;
        }
    }
}
