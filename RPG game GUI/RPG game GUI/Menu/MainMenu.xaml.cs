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

namespace RPG_game_GUI.Menu
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl, ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click_NewGame(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Loading());
        }

        private void Button_Click_LoadGame(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.LoadGame());
        }

        private void Button_Click_Options(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Options());
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_Credits(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Credits());
        }
    }
}
