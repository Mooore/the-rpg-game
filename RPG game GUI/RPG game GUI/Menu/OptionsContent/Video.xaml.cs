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

            setSelectedItem();
        }

        private void setSelectedItem()
        {
            if (Convert.ToString(App.Current.Properties["size"]) == "H")
            {
                resolution.SelectedIndex = 0;
                set1920();
            }
            else if (Convert.ToString(App.Current.Properties["size"]) == "M")
            {
                resolution.SelectedIndex = 1;
                set1366();
            }
            else
            {
                resolution.SelectedIndex = 2;
                set1024();
            }
        }

        private void set1920()
        {
            lbl_resolution.FontSize = 20;
            lbl_resolution.Margin = new Thickness(170, 0, 0, 0);

            resolution.FontSize = 16;
            resolution.Margin = new Thickness(90, 0, 0, 0);

            btnBack.FontSize = 22;
            btnBack.Padding = new Thickness(15, 5, 15, 5);
            btnBack.Margin = new Thickness(0, 0, 100, 0);
            
            btnSave.FontSize = 22;
            btnSave.Padding = new Thickness(15, 5, 15, 5);
            btnSave.Margin = new Thickness(100, 0, 0, 0);
        }

        private void set1366()
        {
            lbl_resolution.FontSize = 15;
            lbl_resolution.Margin = new Thickness(50, 0, 0, 0);

            resolution.FontSize = 12;
            resolution.Margin = new Thickness(50, 0, 0, 0);

            btnBack.FontSize = 16;
            btnBack.Padding = new Thickness(10, 5, 10, 5);
            btnBack.Margin = new Thickness(0, 0, 70, 0);

            btnSave.FontSize = 16;
            btnSave.Padding = new Thickness(10, 5, 10, 5);
            btnSave.Margin = new Thickness(70, 0, 0, 0);
        }

        private void set1024()
        {
            lbl_resolution.FontSize = 13;
            lbl_resolution.Margin = new Thickness(20, 0, 0, 0);

            resolution.FontSize = 12;
            resolution.Margin = new Thickness(10, 0, 0, 0);

            btnBack.FontSize = 14;
            btnBack.Padding = new Thickness(8, 4, 8, 4);
            btnBack.Margin = new Thickness(0, 0, 30, 0);

            btnSave.FontSize = 14;
            btnSave.Padding = new Thickness(8, 4, 8, 4);
            btnSave.Margin = new Thickness(30, 0, 0, 0);
        }

        private void resolution_1920()
        {
            App.Current.MainWindow.Height = 1080;
            App.Current.MainWindow.Width = 1920;
            App.Current.Properties["size"] = "H";
            changeWindowProperties();
            set1920();
        }

        private void resolution_1366()
        {
            App.Current.MainWindow.Height = 768;
            App.Current.MainWindow.Width = 1366;
            App.Current.Properties["size"] = "M";
            changeWindowProperties();
            set1366();
        }

        private void resolution_1024()
        {
            App.Current.MainWindow.Height = 768;
            App.Current.MainWindow.Width = 1024;
            App.Current.Properties["size"] = "S";
            changeWindowProperties();
            set1024();
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

            MainMenu win = new Menu.MainMenu();
            win.setSizeItems();

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
                resolution_1920();
            }
            else if (resolution.SelectedIndex == 1)
            {
                resolution_1366();
            }
            else
            {
                resolution_1024();
            }
        }
    }
}
