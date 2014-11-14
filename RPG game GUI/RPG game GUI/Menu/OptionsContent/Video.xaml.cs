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
        }

        private void btn1920_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Height = 1024;
            App.Current.MainWindow.Width = 1920;
            changeWindowProperties();
        }

        private void btn1366_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Height = 768;
            App.Current.MainWindow.Width = 1366;
            changeWindowProperties();
        }

        private void btn1024_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Height = 768;
            App.Current.MainWindow.Width = 1024;
            changeWindowProperties();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Menu.Options();
        }

        private void changeWindowProperties()
        {
            App.Current.MainWindow.WindowState = WindowState.Normal;
            App.Current.MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            App.Current.MainWindow.ResizeMode = ResizeMode.CanMinimize;
            App.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

    }
}
