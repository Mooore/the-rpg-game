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
using System.Windows.Media.Animation;

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
            //Switcher.Switch(new Menu.MainMenu());
            //(this.Parent as Border);

            App.Current.Properties["is_load"] = false;
            (this.Parent as Border).IsEnabled = false;

            DoubleAnimation fade_out = new DoubleAnimation();
            Duration animate_dur = new Duration(TimeSpan.FromSeconds(1.5));
            fade_out.Duration = animate_dur;

            Storyboard sb = new Storyboard();
            sb.Duration = animate_dur;
            sb.Children.Add(fade_out);

            Storyboard.SetTarget(fade_out, (this.Parent as Border));
            Storyboard.SetTargetProperty(fade_out, new PropertyPath("(Opacity)"));

            fade_out.From = 1;
            fade_out.To = 0;

            ThicknessAnimation margin_out = new ThicknessAnimation();
            margin_out.Duration = animate_dur;

            Storyboard sb2 = new Storyboard();
            sb2.Duration = animate_dur;
            sb2.Children.Add(margin_out);

            Storyboard.SetTarget(margin_out, (this.Parent as Border));
            Storyboard.SetTargetProperty(margin_out, new PropertyPath("(Margin)"));

            margin_out.From = new Thickness(0, 0, 0, 0);
            margin_out.To = new Thickness(0, 100, 0, 0);

            sb.Begin();
            sb2.Begin();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void btnLoad1_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_load"] = false;
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad2_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_load"] = false;
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad3_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_load"] = false;
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad4_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_load"] = false;
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad5_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_load"] = false;
            Switcher.Switch(new Menu.Loading());
        }

        private void btnLoad6_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_load"] = false;
            Switcher.Switch(new Menu.Loading());
        }
    }
}
