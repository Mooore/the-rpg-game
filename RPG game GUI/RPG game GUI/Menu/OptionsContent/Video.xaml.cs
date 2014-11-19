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

namespace RPG_game_GUI.Menu.OptionsContent
{
    /// <summary>
    /// Interakční logika pro UserControl1.xaml
    /// </summary>
    public partial class Video : UserControl
    {
        public Video()
        {
            InitializeComponent();
            double width = Convert.ToDouble(App.Current.Properties["width"]);
            double height = Convert.ToDouble(App.Current.Properties["height"]);


            if ((width == 1920) && (height == 1080))
            {
                resolution.SelectedIndex = 0;
            }
            else if ((width == 1366) && (height == 768))
            {
                resolution.SelectedIndex = 1;
            }
            else
            {
                resolution.SelectedIndex = 2;
            }

        }

        private void resolution_1920()
        {
            App.Current.MainWindow.Height = 1080;
            App.Current.MainWindow.Width = 1920;
            changeWindowProperties();
        }

        private void resolution_1366()
        {
            App.Current.MainWindow.Height = 768;
            App.Current.MainWindow.Width = 1366;
            changeWindowProperties();
        }

        private void resolution_1024()
        {
            App.Current.MainWindow.Height = 768;
            App.Current.MainWindow.Width = 1024;
            changeWindowProperties();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Menu.Options();
            App.Current.Properties["is_option"] = true;
        }

        private void changeWindowProperties()
        {
            double width = Convert.ToDouble(App.Current.Properties["width"]);
            double height = Convert.ToDouble(App.Current.Properties["height"]);

            
            if((width == App.Current.MainWindow.Width) && (height == App.Current.MainWindow.Height)){
                App.Current.MainWindow.WindowStyle = WindowStyle.None;
                App.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
                App.Current.MainWindow.WindowState = WindowState.Maximized;
                
                App.Current.MainWindow.Topmost = true;
                App.Current.MainWindow.Activate();
            }
            else {
                App.Current.MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                App.Current.MainWindow.ResizeMode = ResizeMode.CanMinimize;
                App.Current.MainWindow.WindowState = WindowState.Normal;
                App.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (resolution.SelectedIndex == 0)
            {
                this.resolution_1920();
            }
            else if (resolution.SelectedIndex == 1)
            {
                this.resolution_1366();
            }
            else
            {
                this.resolution_1024();
            }
        }
    }
}
