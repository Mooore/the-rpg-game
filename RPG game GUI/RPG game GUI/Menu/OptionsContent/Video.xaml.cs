using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;
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
using System.Windows.Threading;
using System.IO;
using System.Xaml;

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

            vsync.SelectedIndex = 0;
            anti.SelectedIndex = 2;
            graph_q.SelectedIndex = 2;
            effec_q.SelectedIndex = 2;
            shad_q.SelectedIndex = 2;
            text_q.SelectedIndex = 2;
            

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
            resolution.FontSize = 16;
            vsync.FontSize = 16;
            anti.FontSize = 16;
            graph_q.FontSize = 16;
            effec_q.FontSize = 16;
            shad_q.FontSize = 16;
            text_q.FontSize = 16;
            bright.Width = 250;

            
        }

        private void set1366()
        {
            resolution.FontSize = 12;
            vsync.FontSize = 12;
            anti.FontSize = 12;
            graph_q.FontSize = 12;
            effec_q.FontSize = 12;
            shad_q.FontSize = 12;
            text_q.FontSize = 12;
            bright.Width = 150;
        }

        private void set1024()
        {
            resolution.FontSize = 12;
            vsync.FontSize = 12;
            anti.FontSize = 12;
            graph_q.FontSize = 12;
            effec_q.FontSize = 12;
            shad_q.FontSize = 12;
            text_q.FontSize = 12;
            bright.Width = 100;
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

        /// <summary>
        /// Funkce která zajístí spoždění pro vytracení menu a přepnutí do Loading screen po určitém čase.
        /// </summary>
        /// <param name="seconds">Kolik sekund bude čekat</param>
        private void Wait(double seconds)
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(seconds) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                this.Content = new Menu.Options();

                DoubleAnimation fade_in = new DoubleAnimation();
                Duration animate_durat = new Duration(TimeSpan.FromSeconds(1.5));
                fade_in.Duration = animate_durat;

                Storyboard sbopt12 = new Storyboard();
                sbopt12.Duration = animate_durat;
                sbopt12.Children.Add(fade_in);

                Storyboard.SetTarget(fade_in, (this.Parent as Border));
                Storyboard.SetTargetProperty(fade_in, new PropertyPath("(Opacity)"));

                fade_in.From = 0;
                fade_in.To = 1;

                ThicknessAnimation margin_in = new ThicknessAnimation();
                margin_in.Duration = animate_durat;

                Storyboard sbopt22 = new Storyboard();
                sbopt22.Duration = animate_durat;
                sbopt22.Children.Add(margin_in);

                Storyboard.SetTarget(margin_in, (this.Parent as Border));
                Storyboard.SetTargetProperty(margin_in, new PropertyPath("(Margin)"));

                margin_in.From = new Thickness(0, 100, 0, 0);
                margin_in.To = new Thickness(0, 0, 0, 0);

                sbopt12.Begin();
                sbopt22.Begin();
            };
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //this.Content = new Menu.Options();

            Grid mainGrid = VisualTreeHelper.GetParent(this) as Grid;
            UserControl myOptions = (UserControl)mainGrid.FindName("ucOptions");

            DoubleAnimation fade_out = new DoubleAnimation();
            Duration animate_durat = new Duration(TimeSpan.FromSeconds(1.5));
            fade_out.Duration = animate_durat;

            Storyboard sbopt3 = new Storyboard();
            sbopt3.Duration = animate_durat;
            sbopt3.Children.Add(fade_out);

            Storyboard.SetTarget(fade_out, this);
            Storyboard.SetTargetProperty(fade_out, new PropertyPath("(Opacity)"));

            fade_out.From = 1;
            fade_out.To = 0;

            ThicknessAnimation margin_out = new ThicknessAnimation();
            margin_out.Duration = animate_durat;

            Storyboard sbopt23 = new Storyboard();
            sbopt23.Duration = animate_durat;
            sbopt23.Children.Add(margin_out);

            Storyboard.SetTarget(margin_out, this);
            Storyboard.SetTargetProperty(margin_out, new PropertyPath("(Margin)"));

            margin_out.From = new Thickness(0, 0, 0, 0);
            margin_out.To = new Thickness(0, 100, 0, 0);

            sbopt3.Begin();
            sbopt23.Begin();

            Panel.SetZIndex(this, 1);
            Panel.SetZIndex(myOptions, 10);

            DoubleAnimation fade_in = new DoubleAnimation();
            fade_in.Duration = animate_durat;

            Storyboard sbopt12 = new Storyboard();
            sbopt12.Duration = animate_durat;
            sbopt12.Children.Add(fade_in);

            Storyboard.SetTarget(fade_in, myOptions);
            Storyboard.SetTargetProperty(fade_in, new PropertyPath("(Opacity)"));

            fade_in.From = 0;
            fade_in.To = 1;

            ThicknessAnimation margin_in = new ThicknessAnimation();
            margin_in.Duration = animate_durat;

            Storyboard sbopt22 = new Storyboard();
            sbopt22.Duration = animate_durat;
            sbopt22.Children.Add(margin_in);

            Storyboard.SetTarget(margin_in, myOptions);
            Storyboard.SetTargetProperty(margin_in, new PropertyPath("(Margin)"));

            margin_in.From = new Thickness(0, 100, 0, 0);
            margin_in.To = new Thickness(0, 0, 0, 0);

            sbopt12.Begin();
            sbopt22.Begin();

            //Wait(1.5);
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
