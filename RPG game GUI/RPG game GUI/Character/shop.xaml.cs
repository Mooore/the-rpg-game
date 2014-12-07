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

namespace RPG_game_GUI.Character
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class shop : UserControl
    {
        public shop()
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
             * Skrytí obchodu
             */
            if (e.Key == Key.O || e.Key == Key.Tab)
            {
                (this.Parent as Viewbox).Visibility = Visibility.Hidden;
            }
        }
        /*
         * Zajišťuje, že je okno přetahovatelné a dá se volně umístit, kde uživatel chce.
         */
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Canvas.SetLeft(this.Parent as Viewbox, Canvas.GetLeft(this.Parent as Viewbox) + e.HorizontalChange);
            Canvas.SetTop(this.Parent as Viewbox, Canvas.GetTop(this.Parent as Viewbox) + e.VerticalChange);
        }

        private void Label6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pom = money.Content;
            int pom2 = Convert.ToInt32(pom);
            money.Content = pom2 - 7000;
        }

        private void Label5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pom = money.Content;
            int pom2 = Convert.ToInt32(pom);
            money.Content = pom2 - 5000;
        }

        private void Label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pom = money.Content;
            int pom2 = Convert.ToInt32(pom);
            money.Content = pom2 - 20000;
        }

        private void Label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pom = money.Content;
            int pom2 = Convert.ToInt32(pom);
            money.Content = pom2 - 1000;
        }

        private void Label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pom = money.Content;
            int pom2 = Convert.ToInt32(pom);
            money.Content = pom2 - 450;
        }

        private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pom = money.Content;
            int pom2 = Convert.ToInt32(pom);
            money.Content = pom2 - 500;
        }

    }
}

