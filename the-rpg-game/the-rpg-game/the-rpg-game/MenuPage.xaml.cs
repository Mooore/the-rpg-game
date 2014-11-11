using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Šablona položky "Blank Page" je popsána na adrese  http://go.microsoft.com/fwlink/?LinkId=234238

namespace the_rpg_game
{
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
            if (this.MenuFrame.Visibility == Visibility.Visible)
            {
                this.MenuFrame.Visibility = Visibility.Collapsed;
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GamePage));       
        }

        private void ExitGameButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
            
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.MenuFrame.Visibility = Visibility.Visible;
            this.MenuFrame.Navigate(typeof(LoadGamePage));
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.MenuFrame.Visibility = Visibility.Visible;
            this.MenuFrame.Navigate(typeof(OptionsPage));
        }

    }
}
