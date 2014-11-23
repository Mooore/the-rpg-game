﻿using System;
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

namespace RPG_game_GUI.Character
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Viewbox).Visibility = Visibility.Hidden;
        }
        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            /*
             * Skrytí statistik
             */
            if (e.Key == Key.C || e.Key == Key.Tab)
            {
                (this.Parent as Viewbox).Visibility = Visibility.Hidden;
            }
        }

    }
}
