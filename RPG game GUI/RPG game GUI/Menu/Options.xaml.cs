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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : UserControl
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.MainMenu());
        }

        private void btnVideo_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_option"] = false;
            this.Content = new Menu.OptionsContent.Video();
        }

        private void btnSound_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_option"] = false;
        }

        private void btnKeyboard_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_option"] = false;
        }
    }
}
