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

namespace RPG_game_GUI.Menu
{
    /// <summary>
    /// Interaction logic for Triforce.xaml
    /// </summary>
    public partial class Triforce : UserControl, ISwitchable
    {
        public Triforce()
        {
            InitializeComponent();
            initVisibility();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void triMiddle_MouseEnter(object sender, MouseEventArgs e)
        {
            hideAll();
            imgTriforce.Source = (ImageSource)Resources["Middle"];
            lbName.Content = "Odpojit";
            lbName.Visibility = Visibility.Visible;
        }

        private void triMiddle_MouseLeave(object sender, MouseEventArgs e)
        {
            imgTriforce.Source = (ImageSource)Resources["Triforce"];
        }

        private void triTop_MouseEnter(object sender, MouseEventArgs e)
        {
            imgTriforce.Source = (ImageSource)Resources["Top"];
            hideAll();
            lbName.Content = "Postava";
            lbName.Visibility = Visibility.Visible;
            btnAbility.Visibility = Visibility.Visible;
            btnChar.Visibility = Visibility.Visible;
            btnInv1.Visibility = Visibility.Visible;
            btnStat.Visibility = Visibility.Visible;
            btnTalent.Visibility = Visibility.Visible;
        }

        private void triTop_MouseLeave(object sender, MouseEventArgs e)
        {
            //imgTriforce.Source = (ImageSource)Resources["Triforce"];
        }

        private void triLeft_MouseEnter(object sender, MouseEventArgs e)
        {
            imgTriforce.Source = (ImageSource)Resources["Left"];
            hideAll();
            lbName3.Visibility = Visibility.Visible;
            btnFrakce.Visibility = Visibility.Visible;
            btnMapa.Visibility = Visibility.Visible;
            btnObchod.Visibility = Visibility.Visible;
            btnQuest.Visibility = Visibility.Visible;
            btnWiki.Visibility = Visibility.Visible;
            btnZpravy.Visibility = Visibility.Visible;
            btnPratele.Visibility = Visibility.Visible;
        }

        private void triLeft_MouseLeave(object sender, MouseEventArgs e)
        {
            //imgTriforce.Source = (ImageSource)Resources["Triforce"];
        }

        private void triRight_MouseEnter(object sender, MouseEventArgs e)
        {
            imgTriforce.Source = (ImageSource)Resources["Right"];
            hideAll();
            lbName2.Visibility = Visibility.Visible;
            btnExit.Visibility = Visibility.Visible;
            btnLoad.Visibility = Visibility.Visible;
            btnNevim.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            btnSetting.Visibility = Visibility.Visible;
        }

        private void triRight_MouseLeave(object sender, MouseEventArgs e)
        {
            //imgTriforce.Source = (ImageSource)Resources["Triforce"];
        }

        private void triMiddle_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete ukončit hru?", "Ukončit hru", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
            {
                Switcher.Switch(new Menu.MainMenu());
            }
        }

        private void hideAll()
        {
            lbName.Visibility = Visibility.Hidden;
            lbName2.Visibility = Visibility.Hidden;
            lbName3.Visibility = Visibility.Hidden;
            btnAbility.Visibility = Visibility.Hidden;
            btnChar.Visibility = Visibility.Hidden;
            btnExit.Visibility = Visibility.Hidden;
            btnFrakce.Visibility = Visibility.Hidden;
            btnInv1.Visibility = Visibility.Hidden;
            btnLoad.Visibility = Visibility.Hidden;
            btnMapa.Visibility = Visibility.Hidden;
            btnNevim.Visibility = Visibility.Hidden;
            btnObchod.Visibility = Visibility.Hidden;
            btnPratele.Visibility = Visibility.Hidden;
            btnQuest.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Hidden;
            btnSetting.Visibility = Visibility.Hidden;
            btnStat.Visibility = Visibility.Hidden;
            btnTalent.Visibility = Visibility.Hidden;
            btnWiki.Visibility = Visibility.Hidden;
            btnZpravy.Visibility = Visibility.Hidden;
        }

        private void initVisibility()
        {
            hideAll();
            lbAbility.Visibility = Visibility.Hidden;
            lbExit.Visibility = Visibility.Hidden;
            lbFrakce.Visibility = Visibility.Hidden;
            lbChar.Visibility = Visibility.Hidden;
            lbInv.Visibility = Visibility.Hidden;
            lbLoad.Visibility = Visibility.Hidden;
            lbMapa.Visibility = Visibility.Hidden;
            lbName.Visibility = Visibility.Hidden;
            lbName2.Visibility = Visibility.Hidden;
            lbName3.Visibility = Visibility.Hidden;
            lbNevim.Visibility = Visibility.Hidden;
            lbObchod.Visibility = Visibility.Hidden;
            lbPratele.Visibility = Visibility.Hidden;
            lbQuest.Visibility = Visibility.Hidden;
            lbSave.Visibility = Visibility.Hidden;
            lbSettings.Visibility = Visibility.Hidden;
            lbStat.Visibility = Visibility.Hidden;
            lbtalent.Visibility = Visibility.Hidden;
            lbWiki.Visibility = Visibility.Hidden;
            lbZpravy.Visibility = Visibility.Hidden;
        }

        private void btnStat_MouseEnter(object sender, MouseEventArgs e)
        {
            lbStat.Visibility = Visibility.Visible;
        }

        private void btnStat_MouseLeave(object sender, MouseEventArgs e)
        {
            lbStat.Visibility = Visibility.Hidden;
        }

        private void btnInv1_MouseEnter(object sender, MouseEventArgs e)
        {
            lbInv.Visibility = Visibility.Visible;
        }

        private void btnInv1_MouseLeave(object sender, MouseEventArgs e)
        {
            lbInv.Visibility = Visibility.Hidden;
        }

        private void btnChar_MouseEnter(object sender, MouseEventArgs e)
        {
            lbChar.Visibility = Visibility.Visible;
        }

        private void btnChar_MouseLeave(object sender, MouseEventArgs e)
        {
            lbChar.Visibility = Visibility.Hidden;
        }

        private void btnTalent_MouseEnter(object sender, MouseEventArgs e)
        {
            lbtalent.Visibility = Visibility.Visible;
        }

        private void btnTalent_MouseLeave(object sender, MouseEventArgs e)
        {
            lbtalent.Visibility = Visibility.Hidden;
        }

        private void btnAbility_MouseEnter(object sender, MouseEventArgs e)
        {
            lbAbility.Visibility = Visibility.Visible;
        }

        private void btnAbility_MouseLeave(object sender, MouseEventArgs e)
        {
            lbAbility.Visibility = Visibility.Hidden;
        }

        private void btnMapa_MouseEnter(object sender, MouseEventArgs e)
        {
            lbMapa.Visibility = Visibility.Visible;
        }

        private void btnMapa_MouseLeave(object sender, MouseEventArgs e)
        {
            lbMapa.Visibility = Visibility.Hidden;
        }

        private void btnObchod_MouseEnter(object sender, MouseEventArgs e)
        {
            lbObchod.Visibility = Visibility.Visible;
        }

        private void btnObchod_MouseLeave(object sender, MouseEventArgs e)
        {
            lbObchod.Visibility = Visibility.Hidden;
        }

        private void btnQuest_MouseEnter(object sender, MouseEventArgs e)
        {
            lbQuest.Visibility = Visibility.Visible;
        }

        private void btnQuest_MouseLeave(object sender, MouseEventArgs e)
        {
            lbQuest.Visibility = Visibility.Hidden;
        }

        private void btnFrakce_MouseEnter(object sender, MouseEventArgs e)
        {
            lbFrakce.Visibility = Visibility.Visible;
        }

        private void btnFrakce_MouseLeave(object sender, MouseEventArgs e)
        {
            lbFrakce.Visibility = Visibility.Hidden;
        }

        private void btnZpravy_MouseEnter(object sender, MouseEventArgs e)
        {
            lbZpravy.Visibility = Visibility.Visible;
        }

        private void btnZpravy_MouseLeave(object sender, MouseEventArgs e)
        {
            lbZpravy.Visibility = Visibility.Hidden;
        }

        private void btnPratele_MouseEnter(object sender, MouseEventArgs e)
        {
            lbPratele.Visibility = Visibility.Visible;
        }

        private void btnPratele_MouseLeave(object sender, MouseEventArgs e)
        {
            lbPratele.Visibility = Visibility.Hidden;
        }

        private void btnWiki_MouseEnter(object sender, MouseEventArgs e)
        {
            lbWiki.Visibility = Visibility.Visible;
        }

        private void btnWiki_MouseLeave(object sender, MouseEventArgs e)
        {
            lbWiki.Visibility = Visibility.Hidden;
        }

        private void btnSave_MouseEnter(object sender, MouseEventArgs e)
        {
            lbSave.Visibility = Visibility.Visible;
        }

        private void btnSave_MouseLeave(object sender, MouseEventArgs e)
        {
            lbSave.Visibility = Visibility.Hidden;
        }

        private void btnLoad_MouseEnter(object sender, MouseEventArgs e)
        {
            lbLoad.Visibility = Visibility.Visible;
        }

        private void btnLoad_MouseLeave(object sender, MouseEventArgs e)
        {
            lbLoad.Visibility = Visibility.Hidden;
        }

        private void btnExit_MouseEnter(object sender, MouseEventArgs e)
        {
            lbExit.Visibility = Visibility.Visible;
        }

        private void btnExit_MouseLeave(object sender, MouseEventArgs e)
        {
            lbExit.Visibility = Visibility.Hidden;
        }

        private void btnSetting_MouseEnter(object sender, MouseEventArgs e)
        {
            lbSettings.Visibility = Visibility.Visible;
        }

        private void btnSetting_MouseLeave(object sender, MouseEventArgs e)
        {
            lbSettings.Visibility = Visibility.Hidden;
        }

        private void btnNevim_MouseEnter(object sender, MouseEventArgs e)
        {
            lbNevim.Visibility = Visibility.Visible;
        }

        private void btnNevim_MouseLeave(object sender, MouseEventArgs e)
        {
            lbNevim.Visibility = Visibility.Hidden;
        }

        
    }
}
