﻿using System;
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



namespace RPG_game_GUI.Menu
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    /// 
    public partial class MainMenu : UserControl, ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();
            
            if(App.Current.Properties["is_option"].ToString() == "True") 
            {
                borOptions.Visibility = Visibility.Visible;
            }
            setSizeItems();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        public void setSizeItems()
        {
            if (Convert.ToString(App.Current.Properties["size"]) == "H")
            {
                set1920();
            }
            else if (Convert.ToString(App.Current.Properties["size"]) == "M")
            {
                set1366();
            }
            else
            {
                set1024();
            }
        }

        private void set1920()
        {
            btnStart.Margin = new Thickness(30, 10, 30, 10);
            btnStart.FontSize = 20;
            btnStart.Padding = new Thickness(15, 5, 15, 5);

            btnLoad.Margin = new Thickness(30, 10, 30, 10);
            btnLoad.FontSize = 20;
            btnLoad.Padding = new Thickness(15, 5, 15, 5);

            btnOptions.Margin = new Thickness(30, 10, 30, 10);
            btnOptions.FontSize = 20;
            btnOptions.Padding = new Thickness(15, 5, 15, 5);

            btnExit.Margin = new Thickness(30, 10, 20, 10);
            btnExit.FontSize = 20;
            btnExit.Padding = new Thickness(10, 5, 10, 5);

            btnCredits.Margin = new Thickness(0, 15, 0, 0);
        }

        private void set1366()
        {
            btnStart.Margin = new Thickness(20, 10, 20, 10);
            btnStart.FontSize = 16;
            btnStart.Padding = new Thickness(10, 5, 10, 5);

            btnLoad.Margin = new Thickness(20, 10, 20, 10);
            btnLoad.FontSize = 16;
            btnLoad.Padding = new Thickness(10, 5, 10, 5);

            btnOptions.Margin = new Thickness(20, 10, 20, 10);
            btnOptions.FontSize = 16;
            btnOptions.Padding = new Thickness(10, 5, 10, 5);

            btnExit.Margin = new Thickness(20, 10, 20, 10);
            btnExit.FontSize = 16;
            btnExit.Padding = new Thickness(10, 5, 10, 5);

            btnCredits.Margin = new Thickness(0, 15, 0, 0);
        }

        private void set1024()
        {
            btnStart.Margin = new Thickness(10, 5, 10, 5);
            btnStart.FontSize = 13;
            btnStart.Padding = new Thickness(8, 5, 8, 5);

            btnLoad.Margin = new Thickness(10, 5, 10, 5);
            btnLoad.FontSize = 13;
            btnLoad.Padding = new Thickness(8, 5, 8, 5);

            btnOptions.Margin = new Thickness(10, 5, 10, 5);
            btnOptions.FontSize = 13;
            btnOptions.Padding = new Thickness(8, 5, 8, 5);

            btnExit.Margin = new Thickness(10, 5, 10, 5);
            btnExit.FontSize = 13;
            btnExit.Padding = new Thickness(8, 5, 8, 5);

            btnCredits.Margin = new Thickness(0, 10, 0, 0);
        }

        /// <summary>
        /// Funkce která zajístí spoždění pro vytracení menu a přepnutí do Loading screen po určitém čase.
        /// </summary>
        /// <param name="seconds">Kolik sekund bude čekat</param>
        private void Wait(int seconds)
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(seconds) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                Switcher.Switch(new Menu.Loading());
            };
        }

        private void Button_Click_NewGame(object sender, RoutedEventArgs e)
        {
            Grid.SetZIndex(BlackOut, 10);

            DoubleAnimation Fade = new DoubleAnimation();
            Fade.Duration = new Duration(TimeSpan.FromSeconds(1));

            Storyboard story = new Storyboard();
            story.Duration = Fade.Duration;
            story.Children.Add(Fade);

            Storyboard.SetTarget(Fade, BlackOut);
            Storyboard.SetTargetProperty(Fade, new PropertyPath("(Opacity)"));

            Fade.From = 0;
            Fade.To = 1;

            story.Begin();

            Wait(2);
        }

        private void Button_Click_LoadGame(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(App.Current.Properties["is_load"]) == true)
            {
                App.Current.Properties["is_load"] = false; 
                    
                DoubleAnimation fade_out = new DoubleAnimation();
                Duration animate_dur = new Duration(TimeSpan.FromSeconds(1.5));
                fade_out.Duration = animate_dur;

                Storyboard sb = new Storyboard();
                sb.Duration = animate_dur;
                sb.Children.Add(fade_out);

                Storyboard.SetTarget(fade_out, borLoadGame);
                Storyboard.SetTargetProperty(fade_out, new PropertyPath("(Opacity)"));

                fade_out.From = 1;
                fade_out.To = 0;

                ThicknessAnimation margin_out = new ThicknessAnimation();
                margin_out.Duration = animate_dur;

                Storyboard sb2 = new Storyboard();
                sb2.Duration = animate_dur;
                sb2.Children.Add(margin_out);

                Storyboard.SetTarget(margin_out, borLoadGame);
                Storyboard.SetTargetProperty(margin_out, new PropertyPath("(Margin)"));

                margin_out.From = new Thickness(0, 0, 0, 0);
                margin_out.To = new Thickness(0, 100, 0, 0);
                    
                sb.Begin();
                sb2.Begin();
            }
            else
            {
                if (borLoadGame.Visibility == Visibility.Hidden)
                {
                    borLoadGame.Visibility = Visibility.Visible;
                }

                if (Convert.ToBoolean(App.Current.Properties["is_option"]) != false)
                {
                    //borOptions.Visibility = Visibility.Hidden;

                    App.Current.Properties["is_option"] = false;
                   
                    DoubleAnimation fade_out1 = new DoubleAnimation();
                    Duration animate_dur1 = new Duration(TimeSpan.FromSeconds(1.5));
                    fade_out1.Duration = animate_dur1;

                    Storyboard sb1 = new Storyboard();
                    sb1.Duration = animate_dur1;
                    sb1.Children.Add(fade_out1);

                    Storyboard.SetTarget(fade_out1, borOptions);
                    Storyboard.SetTargetProperty(fade_out1, new PropertyPath("(Opacity)"));

                    fade_out1.From = 1;
                    fade_out1.To = 0;

                    ThicknessAnimation margin_out = new ThicknessAnimation();
                    margin_out.Duration = animate_dur1;

                    Storyboard sb12 = new Storyboard();
                    sb12.Duration = animate_dur1;
                    sb12.Children.Add(margin_out);

                    Storyboard.SetTarget(margin_out, borOptions);
                    Storyboard.SetTargetProperty(margin_out, new PropertyPath("(Margin)"));

                    margin_out.From = new Thickness(0, 0, 0, 0);
                    margin_out.To = new Thickness(0, 100, 0, 0);

                    sb1.Begin();
                    sb12.Begin();
                }

                App.Current.Properties["is_load"] = true;
                
                DoubleAnimation fade_in = new DoubleAnimation();
                Duration animate_dur = new Duration(TimeSpan.FromSeconds(1.5));
                fade_in.Duration = animate_dur;

                Storyboard sb = new Storyboard();
                sb.Duration = animate_dur;
                sb.Children.Add(fade_in);

                Storyboard.SetTarget(fade_in, borLoadGame);
                Storyboard.SetTargetProperty(fade_in, new PropertyPath("(Opacity)"));

                fade_in.From = 0;
                fade_in.To = 1;

                ThicknessAnimation margin_in = new ThicknessAnimation();
                margin_in.Duration = animate_dur;

                Storyboard sb2 = new Storyboard();
                sb2.Duration = animate_dur;
                sb2.Children.Add(margin_in);

                Storyboard.SetTarget(margin_in, borLoadGame);
                Storyboard.SetTargetProperty(margin_in, new PropertyPath("(Margin)"));

                margin_in.From = new Thickness(0, 100, 0, 0);
                margin_in.To = new Thickness(0, 0, 0, 0);

                sb.Begin();
                sb2.Begin();
            }
        }

        private void Button_Click_Options(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(App.Current.Properties["is_option"]) == true)
            {
                App.Current.Properties["is_option"] = false;

                DoubleAnimation fade_out = new DoubleAnimation();
                Duration animate_dur = new Duration(TimeSpan.FromSeconds(1.5));
                fade_out.Duration = animate_dur;

                Storyboard sb = new Storyboard();
                sb.Duration = animate_dur;
                sb.Children.Add(fade_out);

                Storyboard.SetTarget(fade_out, borOptions);
                Storyboard.SetTargetProperty(fade_out, new PropertyPath("(Opacity)"));

                fade_out.From = 1;
                fade_out.To = 0;

                ThicknessAnimation margin_out = new ThicknessAnimation();
                margin_out.Duration = animate_dur;

                Storyboard sb2 = new Storyboard();
                sb2.Duration = animate_dur;
                sb2.Children.Add(margin_out);

                Storyboard.SetTarget(margin_out, borOptions);
                Storyboard.SetTargetProperty(margin_out, new PropertyPath("(Margin)"));

                margin_out.From = new Thickness(0, 0, 0, 0);
                margin_out.To = new Thickness(0, 100, 0, 0);

                sb.Begin();
                sb2.Begin();
            }
            else
            {
                if (borOptions.Visibility == Visibility.Hidden)
                {
                    borOptions.Visibility = Visibility.Visible;
                }

                if (Convert.ToBoolean(App.Current.Properties["is_load"]) != false)
                {
                    //borLoadGame.Visibility = Visibility.Hidden;
                    App.Current.Properties["is_load"] = false;
                   
                    DoubleAnimation fade_out = new DoubleAnimation();
                    Duration animate_dur1 = new Duration(TimeSpan.FromSeconds(1.5));
                    fade_out.Duration = animate_dur1;

                    Storyboard sb1 = new Storyboard();
                    sb1.Duration = animate_dur1;
                    sb1.Children.Add(fade_out);

                    Storyboard.SetTarget(fade_out, borLoadGame);
                    Storyboard.SetTargetProperty(fade_out, new PropertyPath("(Opacity)"));

                    fade_out.From = 1;
                    fade_out.To = 0;

                    ThicknessAnimation margin_out = new ThicknessAnimation();
                    margin_out.Duration = animate_dur1;

                    Storyboard sb12 = new Storyboard();
                    sb12.Duration = animate_dur1;
                    sb12.Children.Add(margin_out);

                    Storyboard.SetTarget(margin_out, borLoadGame);
                    Storyboard.SetTargetProperty(margin_out, new PropertyPath("(Margin)"));

                    margin_out.From = new Thickness(0, 0, 0, 0);
                    margin_out.To = new Thickness(0, 100, 0, 0);

                    sb1.Begin();
                    sb12.Begin();
                }

                App.Current.Properties["is_option"] = true;
                
                
                DoubleAnimation fade_in = new DoubleAnimation();
                Duration animate_dur = new Duration(TimeSpan.FromSeconds(1.5));
                fade_in.Duration = animate_dur;

                Storyboard sb = new Storyboard();
                sb.Duration = animate_dur;
                sb.Children.Add(fade_in);

                Storyboard.SetTarget(fade_in, borOptions);
                Storyboard.SetTargetProperty(fade_in, new PropertyPath("(Opacity)"));

                fade_in.From = 0;
                fade_in.To = 1;

                ThicknessAnimation margin_in = new ThicknessAnimation();
                margin_in.Duration = animate_dur;

                Storyboard sb2 = new Storyboard();
                sb2.Duration = animate_dur;
                sb2.Children.Add(margin_in);

                Storyboard.SetTarget(margin_in, borOptions);
                Storyboard.SetTargetProperty(margin_in, new PropertyPath("(Margin)"));

                margin_in.From = new Thickness(0, 100, 0, 0);
                margin_in.To = new Thickness(0, 0, 0, 0);

                sb.Begin();
                sb2.Begin();
            }    
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_Credits(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Credits());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lbVersion.Content += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
