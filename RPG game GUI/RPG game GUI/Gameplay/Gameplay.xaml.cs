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

namespace RPG_game_GUI.Gameplay
{
    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : UserControl, ISwitchable
    {
        public Gameplay()
        {
            InitializeComponent();

            this.Height = App.Current.MainWindow.Height;
            this.Width = App.Current.MainWindow.Width;

            

            //double top = (GameCanvas.ActualHeight - element.ActualHeight) / 2;
            //Canvas.SetTop(element, top);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += UserControl_PreviewKeyDown;
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }


        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            /*
             * Zobrazení Triforce  
             */
            if (e.Key == Key.Tab || e.Key == Key.Escape)
            {
                if (vbTriforce.Visibility == Visibility.Visible)
                {
                    vbTriforce.Visibility = Visibility.Hidden;
                    vbBarBlur.Radius = 0;
                    vbCharBlur.Radius = 0;
                    vbMapBlur.Radius = 0;
                    vbBackground.Radius = 0;
                }
                else
                {
                    vbTriforce.Visibility = Visibility.Visible;
                    vbBarBlur.Radius = 10;
                    vbCharBlur.Radius = 10;
                    vbMapBlur.Radius = 10;
                    vbBackground.Radius = 10;
                    vbStatistics.Visibility = Visibility.Hidden;
                }
            }

            /*
             * Zobrazení statistik
             */
            if (e.Key == Key.C && vbTriforce.Visibility == Visibility.Hidden)
            {
                if (vbStatistics.Visibility == Visibility.Visible)
                {
                    vbStatistics.Visibility = Visibility.Hidden;
                }
                else
                {
                    vbStatistics.Visibility = Visibility.Visible;
                }
            }
        }

        private void QuickBar_Loaded(object sender, RoutedEventArgs e)
        {
            double left = (GameCanvas.ActualWidth - QuickBar.ActualWidth) / 2;
            Canvas.SetLeft(QuickBar, left);
        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            if (win.WindowState.ToString() == "Maximized")
            {
                GameCanvas.Height = this.Height;
                GameCanvas.Width = this.Width;
            }
            else
            {
                GameCanvas.Height = this.Height - 30;
                GameCanvas.Width = this.Width - 20;
            }
            
        }

    }
}
