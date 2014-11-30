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
            
            DoubleAnimation fade_out = new DoubleAnimation();
            Duration animate_durat = new Duration(TimeSpan.FromSeconds(1.5));
            fade_out.Duration = animate_durat;

            Storyboard sbopt = new Storyboard();
            sbopt.Duration = animate_durat;
            sbopt.Children.Add(fade_out);

            Storyboard.SetTarget(fade_out, this);
            Storyboard.SetTargetProperty(fade_out, new PropertyPath("(Opacity)"));

            fade_out.From = 1;
            fade_out.To = 0;

            ThicknessAnimation margin_out = new ThicknessAnimation();
            margin_out.Duration = animate_durat;

            Storyboard sbopt2 = new Storyboard();
            sbopt2.Duration = animate_durat;
            sbopt2.Children.Add(margin_out);

            Storyboard.SetTarget(margin_out, this);  
            Storyboard.SetTargetProperty(margin_out, new PropertyPath("(Margin)"));

            margin_out.From = new Thickness(0, 0, 0, 0);
            margin_out.To = new Thickness(0, 100, 0, 0);

            sbopt.Begin();
            sbopt2.Begin();
        }

        private void btnVideo_Click(object sender, RoutedEventArgs e)
        {
            //this.Content = new Menu.OptionsContent.Video();

            Grid mainGrid = VisualTreeHelper.GetParent(this) as Grid;
            UserControl myVideo = (UserControl)mainGrid.FindName("ucVideo");

            if (myVideo.Visibility == Visibility.Hidden) 
            {
                myVideo.Visibility = Visibility.Visible;
            }
            

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
            Panel.SetZIndex(myVideo, 10);

            DoubleAnimation fade_in = new DoubleAnimation();
            fade_in.Duration = animate_durat;

            Storyboard sbopt12 = new Storyboard();
            sbopt12.Duration = animate_durat;
            sbopt12.Children.Add(fade_in);

            Storyboard.SetTarget(fade_in, myVideo);
            Storyboard.SetTargetProperty(fade_in, new PropertyPath("(Opacity)"));

            fade_in.From = 0;
            fade_in.To = 1;

            ThicknessAnimation margin_in = new ThicknessAnimation();
            margin_in.Duration = animate_durat;

            Storyboard sbopt22 = new Storyboard();
            sbopt22.Duration = animate_durat;
            sbopt22.Children.Add(margin_in);

            Storyboard.SetTarget(margin_in, myVideo);
            Storyboard.SetTargetProperty(margin_in, new PropertyPath("(Margin)"));

            margin_in.From = new Thickness(0, 100, 0, 0);
            margin_in.To = new Thickness(0, 0, 0, 0);

            sbopt12.Begin();
            sbopt22.Begin();

            //Wait(1.5);
        }

        private void btnSound_Click(object sender, RoutedEventArgs e)
        {
            Grid mainGrid = VisualTreeHelper.GetParent(this) as Grid;
            UserControl mySound = (UserControl)mainGrid.FindName("ucSound");

            if (mySound.Visibility == Visibility.Hidden)
            {
                mySound.Visibility = Visibility.Visible;
            }


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
            Panel.SetZIndex(mySound, 10);

            DoubleAnimation fade_in = new DoubleAnimation();
            fade_in.Duration = animate_durat;

            Storyboard sbopt12 = new Storyboard();
            sbopt12.Duration = animate_durat;
            sbopt12.Children.Add(fade_in);

            Storyboard.SetTarget(fade_in, mySound);
            Storyboard.SetTargetProperty(fade_in, new PropertyPath("(Opacity)"));

            fade_in.From = 0;
            fade_in.To = 1;

            ThicknessAnimation margin_in = new ThicknessAnimation();
            margin_in.Duration = animate_durat;

            Storyboard sbopt22 = new Storyboard();
            sbopt22.Duration = animate_durat;
            sbopt22.Children.Add(margin_in);

            Storyboard.SetTarget(margin_in, mySound);
            Storyboard.SetTargetProperty(margin_in, new PropertyPath("(Margin)"));

            margin_in.From = new Thickness(0, 100, 0, 0);
            margin_in.To = new Thickness(0, 0, 0, 0);

            sbopt12.Begin();
            sbopt22.Begin();
        }

        private void btnKeyboard_Click(object sender, RoutedEventArgs e)
        {
            Grid mainGrid = VisualTreeHelper.GetParent(this) as Grid;
            UserControl myKeyboard = (UserControl)mainGrid.FindName("ucKeyboard");

            if (myKeyboard.Visibility == Visibility.Hidden)
            {
                myKeyboard.Visibility = Visibility.Visible;
            }


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
            Panel.SetZIndex(myKeyboard, 10);

            DoubleAnimation fade_in = new DoubleAnimation();
            fade_in.Duration = animate_durat;

            Storyboard sbopt12 = new Storyboard();
            sbopt12.Duration = animate_durat;
            sbopt12.Children.Add(fade_in);

            Storyboard.SetTarget(fade_in, myKeyboard);
            Storyboard.SetTargetProperty(fade_in, new PropertyPath("(Opacity)"));

            fade_in.From = 0;
            fade_in.To = 1;

            ThicknessAnimation margin_in = new ThicknessAnimation();
            margin_in.Duration = animate_durat;

            Storyboard sbopt22 = new Storyboard();
            sbopt22.Duration = animate_durat;
            sbopt22.Children.Add(margin_in);

            Storyboard.SetTarget(margin_in, myKeyboard);
            Storyboard.SetTargetProperty(margin_in, new PropertyPath("(Margin)"));

            margin_in.From = new Thickness(0, 100, 0, 0);
            margin_in.To = new Thickness(0, 0, 0, 0);

            sbopt12.Begin();
            sbopt22.Begin();
        }
    }
}
