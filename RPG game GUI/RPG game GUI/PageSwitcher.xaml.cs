using System;
using System.Windows;
using System.Windows.Controls;

namespace RPG_game_GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PageSwitcher : Window
    {
        public PageSwitcher()
        {
            InitializeComponent();
            App.Current.Properties["width"] = SystemParameters.PrimaryScreenWidth;
            App.Current.Properties["height"] = SystemParameters.PrimaryScreenHeight;
            App.Current.Properties["is_option"] = false;
            
            if ((SystemParameters.PrimaryScreenWidth == 1920) && (SystemParameters.PrimaryScreenHeight == 1080))
            {
                App.Current.Properties["size"] = "H";
            }
            else if ((SystemParameters.PrimaryScreenWidth == 1366) && (SystemParameters.PrimaryScreenHeight == 1024))
            {
                App.Current.Properties["size"] = "M";
            }
            else
            {
                App.Current.Properties["size"] = "S";
            }

            Switcher.pageSwitcher = this;
            Switcher.Switch(new Menu.MainMenu());
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }
    }
}