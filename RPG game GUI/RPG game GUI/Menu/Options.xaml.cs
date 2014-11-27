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
            //Switcher.Switch(new Menu.MainMenu());
            App.Current.Properties["is_option"] = false;
            (this.Parent as Border).IsEnabled = false;

            DoubleAnimation fade_out = new DoubleAnimation();
            Duration animate_durat = new Duration(TimeSpan.FromSeconds(1.5));
            fade_out.Duration = animate_durat;

            Storyboard sbopt = new Storyboard();
            sbopt.Duration = animate_durat;
            sbopt.Children.Add(fade_out);

            Storyboard.SetTarget(fade_out, (this.Parent as Border));
            Storyboard.SetTargetProperty(fade_out, new PropertyPath("(Opacity)"));

            fade_out.From = 1;
            fade_out.To = 0;

            ThicknessAnimation margin_out = new ThicknessAnimation();
            margin_out.Duration = animate_durat;

            Storyboard sbopt2 = new Storyboard();
            sbopt2.Duration = animate_durat;
            sbopt2.Children.Add(margin_out);

            Storyboard.SetTarget(margin_out, (this.Parent as Border));
            Storyboard.SetTargetProperty(margin_out, new PropertyPath("(Margin)"));

            margin_out.From = new Thickness(0, 0, 0, 0);
            margin_out.To = new Thickness(0, 100, 0, 0);

            sbopt.Begin();
            sbopt2.Begin();
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
