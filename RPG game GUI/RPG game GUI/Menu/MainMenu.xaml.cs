﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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

        private void Button_Click_NewGame(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.Loading());
        }

        private void Button_Click_LoadGame(object sender, RoutedEventArgs e)
        {
            //Switcher.Switch(new Menu.LoadGame());
            if (borLoadGame.Visibility == Visibility.Visible)
            {
                if (Convert.ToBoolean(App.Current.Properties["is_load"]) == true)
                {
                    App.Current.Properties["is_load"] = false;
                    
                    borLoadGame.Visibility = Visibility.Hidden;
                }
                else
                {
                    App.Current.Properties["is_load"] = true;
                    borLoadGame.Child = new Menu.LoadGame();
                }
            }
            else
            {
                App.Current.Properties["is_option"] = false;
                borOptions.Visibility = Visibility.Hidden;
                App.Current.Properties["is_load"] = true;
                borLoadGame.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_Options(object sender, RoutedEventArgs e)
        {
            if (borOptions.Visibility == Visibility.Visible)
            {
                if (Convert.ToBoolean(App.Current.Properties["is_option"]) == true)
                {
                    App.Current.Properties["is_option"] = false;
                    borOptions.Visibility = Visibility.Hidden;
                }
                else
                {
                    App.Current.Properties["is_option"] = true;
                    borOptions.Child = new Menu.Options();
                }
            }
            else 
            {
                App.Current.Properties["is_load"] = false;
                borLoadGame.Visibility = Visibility.Hidden;
                App.Current.Properties["is_option"] = true;
                borOptions.Visibility = Visibility.Visible;
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
