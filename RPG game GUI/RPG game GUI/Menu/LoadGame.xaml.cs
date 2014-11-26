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

namespace RPG_game_GUI.Menu
{
    /// <summary>
    /// Interaction logic for LoadGame.xaml
    /// </summary>
    public partial class LoadGame : UserControl, ISwitchable
    {
        public LoadGame()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.MainMenu());
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void btnLoad1_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad2_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad3_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad4_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad5_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad6_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Loading());
        }
    }
}
