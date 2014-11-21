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
                    GameBlur.Radius = 0;
                }
                else
                {
                    vbTriforce.Visibility = Visibility.Visible;
                    GameBlur.Radius = 10;
                }
            }

            /*
             * Zobrazení statistik
             */
            if (e.Key == Key.C)
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

    }
}
