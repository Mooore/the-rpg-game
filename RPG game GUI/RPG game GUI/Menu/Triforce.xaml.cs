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
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace RPG_game_GUI.Menu
{
    /// <summary>
    /// Interaction logic for Triforce.xaml
    /// </summary>
    public partial class Triforce : UserControl, ISwitchable
    {
        const double ANIMATION_TIME = 0.2; // sekundy
        const int DELAY = 120;              // milisekundy

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
        }

        private void triMiddle_MouseLeave(object sender, MouseEventArgs e)
        {
            imgTriforce.Source = (ImageSource)Resources["Triforce"];
        }

        private void triTop_MouseEnter(object sender, MouseEventArgs e)
        {

            if (btnAbility.Visibility != Visibility.Visible)
            {
                imgTriforce.Source = (ImageSource)Resources["Top"];
                hideAll();

                btnAbility.Visibility = Visibility.Visible;
                btnChar.Visibility = Visibility.Visible;
                btnInv.Visibility = Visibility.Visible;
                btnStat.Visibility = Visibility.Visible;
                btnTalent.Visibility = Visibility.Visible;

                TopAnimationEnter();
            }  
        }

        private void triTop_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void triLeft_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnFrakce.Visibility != Visibility.Visible)
            {
                imgTriforce.Source = (ImageSource)Resources["Left"];
                hideAll();

                btnFrakce.Visibility = Visibility.Visible;
                btnMapa.Visibility = Visibility.Visible;
                btnObchod.Visibility = Visibility.Visible;
                btnQuest.Visibility = Visibility.Visible;
                btnWiki.Visibility = Visibility.Visible;
                btnZpravy.Visibility = Visibility.Visible;
                btnPratele.Visibility = Visibility.Visible;

                LeftAnimationEnter();
            }
            
        }

        private void triLeft_MouseLeave(object sender, MouseEventArgs e)
        {
            //imgTriforce.Source = (ImageSource)Resources["Triforce"];
        }

        private void triRight_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnExit.Visibility != Visibility.Visible)
            {
                imgTriforce.Source = (ImageSource)Resources["Right"];
                hideAll();

                btnExit.Visibility = Visibility.Visible;
                btnLoad.Visibility = Visibility.Visible;
                btnNevim.Visibility = Visibility.Visible;
                btnSave.Visibility = Visibility.Visible;
                btnSetting.Visibility = Visibility.Visible;

                RightAnimationEnter();
            }
            
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

        /// <summary>
        /// Skryje všechny tlačítka a hlavní nadpisy
        /// </summary>
        private void hideAll()
        {
            TopAnimationExit();
            LeftAnimationExit();
            RightAnimationExit();
            btnAbility.Visibility = Visibility.Hidden;
            btnChar.Visibility = Visibility.Hidden;
            btnExit.Visibility = Visibility.Hidden;
            btnFrakce.Visibility = Visibility.Hidden;
            btnInv.Visibility = Visibility.Hidden;
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

        /// <summary>
        /// Skryje všechny labely
        /// </summary>
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

        private void btnStat_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Send(Key.Tab);
            PageSwitcher.Send(Key.C);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Menu.MainMenu());
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["is_option"] = true;
            Switcher.Switch(new Menu.MainMenu());
        }

        private void TopAnimationEnter()
        {
            const int LEFT = 384;
            const int TOP = 230;

            DoubleAnimation moveLeft = new DoubleAnimation();
            moveLeft.Duration = new Duration(TimeSpan.FromSeconds(ANIMATION_TIME));
            DoubleAnimation moveTop = new DoubleAnimation();
            moveTop.Duration = new Duration(TimeSpan.FromSeconds(ANIMATION_TIME));

            Storyboard story = new Storyboard();
            story.Duration = moveLeft.Duration;
            story.Children.Add(moveLeft);
            story.Children.Add(moveTop);

            Storyboard.SetTargetProperty(moveLeft, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTargetProperty(moveTop, new PropertyPath("(Canvas.Top)"));            

            /** Statistiky */
            Storyboard.SetTarget(moveLeft, btnStat);
            Storyboard.SetTarget(moveTop, btnStat);            

            moveTop.To = 136;
            moveLeft.To = 322;

            moveLeft.From = LEFT;
            moveTop.From = TOP;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 0);
            story.Begin();

            /** Inventtář */
            Storyboard.SetTarget(moveLeft, btnInv);
            Storyboard.SetTarget(moveTop, btnInv);

            moveLeft.To = 352;
            moveTop.To = 124;

            moveLeft.From = LEFT;
            moveTop.From = TOP;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 1);
            story.Begin();

            /** Charakter */
            Storyboard.SetTarget(moveLeft, btnChar);
            Storyboard.SetTarget(moveTop, btnChar);

            moveLeft.To = 384;
            moveTop.To = 120;

            moveLeft.From = LEFT;
            moveTop.From = TOP;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 2);
            story.Begin();

            /** Talenty */
            Storyboard.SetTarget(moveLeft, btnTalent);
            Storyboard.SetTarget(moveTop, btnTalent);

            moveLeft.To = 416;
            moveTop.To = 124;
             
            moveLeft.From = LEFT;
            moveTop.From = TOP;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 3);
            story.Begin();

            /** Dovednosti */
            Storyboard.SetTarget(moveLeft, btnAbility);
            Storyboard.SetTarget(moveTop, btnAbility);

            moveLeft.To = 448;
            moveTop.To = 136;

            moveLeft.From = LEFT;
            moveTop.From = TOP;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 4);
            story.Begin();
        }

        private void TopAnimationExit()
        {
            const int LEFT = 384;
            const int TOP = 230;

            DoubleAnimation moveLeft = new DoubleAnimation();
            moveLeft.Duration = new Duration(TimeSpan.FromSeconds(0));
            DoubleAnimation moveTop = new DoubleAnimation();
            moveTop.Duration = new Duration(TimeSpan.FromSeconds(0));

            Storyboard story = new Storyboard();
            story.Duration = moveLeft.Duration;
            story.Children.Add(moveLeft);
            story.Children.Add(moveTop);

            Storyboard.SetTargetProperty(moveLeft, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTargetProperty(moveTop, new PropertyPath("(Canvas.Top)"));

            /** Statistiky */
            Storyboard.SetTarget(moveLeft, btnStat);
            Storyboard.SetTarget(moveTop, btnStat);

            moveLeft.To = LEFT;
            moveTop.To = TOP;

            story.Begin();

            /** Inventtář */
            Storyboard.SetTarget(moveLeft, btnInv);
            Storyboard.SetTarget(moveTop, btnInv);

            moveLeft.To = LEFT;
            moveTop.To = TOP;

            story.Begin();

            /** Charakter */
            Storyboard.SetTarget(moveLeft, btnChar);
            Storyboard.SetTarget(moveTop, btnChar);

            moveLeft.To = LEFT;
            moveTop.To = TOP;

            story.Begin();

            /** Talenty */
            Storyboard.SetTarget(moveLeft, btnTalent);
            Storyboard.SetTarget(moveTop, btnTalent);

            moveLeft.To = LEFT;
            moveTop.To = TOP;

            story.Begin();

            /** Dovednosti */
            Storyboard.SetTarget(moveLeft, btnAbility);
            Storyboard.SetTarget(moveTop, btnAbility);

            moveLeft.To = LEFT;
            moveTop.To = TOP;

            story.Begin();
        }

        private void LeftAnimationEnter()
        {
            DoubleAnimation moveLeft = new DoubleAnimation();
            moveLeft.Duration = new Duration(TimeSpan.FromSeconds(ANIMATION_TIME));
            DoubleAnimation moveTop = new DoubleAnimation();
            moveTop.Duration = new Duration(TimeSpan.FromSeconds(ANIMATION_TIME));

            Storyboard story = new Storyboard();
            story.Duration = moveLeft.Duration;
            story.Children.Add(moveLeft);
            story.Children.Add(moveTop);

            Storyboard.SetTargetProperty(moveLeft, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTargetProperty(moveTop, new PropertyPath("(Canvas.Top)"));

            /** Mapa */
            Storyboard.SetTarget(moveLeft, btnMapa);
            Storyboard.SetTarget(moveTop, btnMapa);

            moveTop.To = 358;
            moveLeft.To = 371;

            moveLeft.From = 460;
            moveTop.From = 410;

            story.Begin();
            
            /** Obchod */
            Storyboard.SetTarget(moveLeft, btnObchod);
            Storyboard.SetTarget(moveTop, btnObchod);

            moveTop.To = 339;
            moveLeft.To = 348;

            moveLeft.From = 446;
            moveTop.From = 355;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 1);
            story.Begin();

            /** Úkoly */
            Storyboard.SetTarget(moveLeft, btnQuest);
            Storyboard.SetTarget(moveTop, btnQuest);

            moveTop.To = 327;
            moveLeft.To = 317;

            moveLeft.From = 408;
            moveTop.From = 312;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 2);
            story.Begin();

            /** Frakce */
            Storyboard.SetTarget(moveLeft, btnFrakce);
            Storyboard.SetTarget(moveTop, btnFrakce);

            moveTop.To = 323;
            moveLeft.To = 285;

            moveLeft.From = 365;
            moveTop.From = 278;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 3);
            story.Begin();

            /** Zprávy */
            Storyboard.SetTarget(moveLeft, btnZpravy);
            Storyboard.SetTarget(moveTop, btnZpravy);

            moveTop.To = 326;
            moveLeft.To = 252;

            moveLeft.From = 309;
            moveTop.From = 258;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 4);
            story.Begin();

            /** Přátelé */
            Storyboard.SetTarget(moveLeft, btnPratele);
            Storyboard.SetTarget(moveTop, btnPratele);

            moveTop.To = 339;
            moveLeft.To = 223;

            moveLeft.From = 257;
            moveTop.From = 253;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 5);
            story.Begin();

            /** Databáze */
            Storyboard.SetTarget(moveLeft, btnWiki);
            Storyboard.SetTarget(moveTop, btnWiki);

            moveTop.To = 359;
            moveLeft.To = 196;

            moveLeft.From = 201;
            moveTop.From = 258;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 6);
            story.Begin();
        }

        private void LeftAnimationExit()
        {
            DoubleAnimation moveLeft = new DoubleAnimation();
            moveLeft.Duration = new Duration(TimeSpan.FromSeconds(0));
            DoubleAnimation moveTop = new DoubleAnimation();
            moveTop.Duration = new Duration(TimeSpan.FromSeconds(0));

            Storyboard story = new Storyboard();
            story.Duration = moveLeft.Duration;
            story.Children.Add(moveLeft);
            story.Children.Add(moveTop);

            Storyboard.SetTargetProperty(moveLeft, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTargetProperty(moveTop, new PropertyPath("(Canvas.Top)"));

            /** Mapa */
            Storyboard.SetTarget(moveLeft, btnMapa);
            Storyboard.SetTarget(moveTop, btnMapa);

            moveLeft.To = 460;
            moveTop.To = 410;

            story.Begin();

            /** Obchod */
            Storyboard.SetTarget(moveLeft, btnObchod);
            Storyboard.SetTarget(moveTop, btnObchod);

            moveLeft.To = 446;
            moveTop.To = 355;

            story.Begin();

            /** Úkoly */
            Storyboard.SetTarget(moveLeft, btnQuest);
            Storyboard.SetTarget(moveTop, btnQuest);

            moveLeft.To = 408;
            moveTop.To = 312;

            story.Begin();

            /** Frakce */
            Storyboard.SetTarget(moveLeft, btnFrakce);
            Storyboard.SetTarget(moveTop, btnFrakce);

            moveLeft.To = 365;
            moveTop.To = 278;

            story.Begin();

            /** Zprávy */
            Storyboard.SetTarget(moveLeft, btnZpravy);
            Storyboard.SetTarget(moveTop, btnZpravy);

            moveLeft.To = 309;
            moveTop.To = 258;

            story.Begin();

            /** Přátelé */
            Storyboard.SetTarget(moveLeft, btnPratele);
            Storyboard.SetTarget(moveTop, btnPratele);

            moveLeft.To = 257;
            moveTop.To = 253;

            story.Begin();

            /** Databáze */
            Storyboard.SetTarget(moveLeft, btnWiki);
            Storyboard.SetTarget(moveTop, btnWiki);

            moveLeft.To = 201;
            moveTop.To = 258;

            story.Begin();
        }

        private void RightAnimationEnter()
        {
            DoubleAnimation moveLeft = new DoubleAnimation();
            moveLeft.Duration = new Duration(TimeSpan.FromSeconds(ANIMATION_TIME));
            DoubleAnimation moveTop = new DoubleAnimation();
            moveTop.Duration = new Duration(TimeSpan.FromSeconds(ANIMATION_TIME));

            Storyboard story = new Storyboard();
            story.Duration = moveLeft.Duration;
            story.Children.Add(moveLeft);
            story.Children.Add(moveTop);

            Storyboard.SetTargetProperty(moveLeft, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTargetProperty(moveTop, new PropertyPath("(Canvas.Top)"));

            /** Uložit */
            Storyboard.SetTarget(moveLeft, btnSave);
            Storyboard.SetTarget(moveTop, btnSave);

            moveTop.To = 339;
            moveLeft.To = 421;

            moveLeft.From = 324;
            moveTop.From = 352;

            story.Begin();

            /** Načíst */
            Storyboard.SetTarget(moveLeft, btnLoad);
            Storyboard.SetTarget(moveTop, btnLoad);

            moveTop.To = 327;
            moveLeft.To = 451;

            moveLeft.From = 359;
            moveTop.From = 310;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 1);
            story.Begin();

            /** Konec */
            Storyboard.SetTarget(moveLeft, btnExit);
            Storyboard.SetTarget(moveTop, btnExit);

            moveTop.To = 323;
            moveLeft.To = 483;

            moveLeft.From = 402;
            moveTop.From = 276;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 2);
            story.Begin();

            /** Nastavení */
            Storyboard.SetTarget(moveLeft, btnSetting);
            Storyboard.SetTarget(moveTop, btnSetting);

            moveTop.To = 327;
            moveLeft.To = 515;

            moveLeft.From = 455;
            moveTop.From = 253;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 3);
            story.Begin();

            /** Neklikat */
            Storyboard.SetTarget(moveLeft, btnNevim);
            Storyboard.SetTarget(moveTop, btnNevim);

            moveTop.To = 339;
            moveLeft.To = 545;

            moveLeft.From = 509;
            moveTop.From = 246;

            story.BeginTime = TimeSpan.FromMilliseconds(DELAY * 4);
            story.Begin();
        }

        private void RightAnimationExit()
        {
            DoubleAnimation moveLeft = new DoubleAnimation();
            moveLeft.Duration = new Duration(TimeSpan.FromSeconds(0));
            DoubleAnimation moveTop = new DoubleAnimation();
            moveTop.Duration = new Duration(TimeSpan.FromSeconds(0));

            Storyboard story = new Storyboard();
            story.Duration = moveLeft.Duration;
            story.Children.Add(moveLeft);
            story.Children.Add(moveTop);

            Storyboard.SetTargetProperty(moveLeft, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTargetProperty(moveTop, new PropertyPath("(Canvas.Top)"));

            /** Uložit */
            Storyboard.SetTarget(moveLeft, btnSave);
            Storyboard.SetTarget(moveTop, btnSave);

            moveLeft.To = 324;
            moveTop.To = 352;

            story.Begin();

            /** Načíst */
            Storyboard.SetTarget(moveLeft, btnLoad);
            Storyboard.SetTarget(moveTop, btnLoad);

            moveLeft.To = 359;
            moveTop.To = 310;

            story.Begin();

            /** Konec */
            Storyboard.SetTarget(moveLeft, btnExit);
            Storyboard.SetTarget(moveTop, btnExit);

            moveLeft.To = 402;
            moveTop.To = 276;

            story.Begin();

            /** Nastavení */
            Storyboard.SetTarget(moveLeft, btnSetting);
            Storyboard.SetTarget(moveTop, btnSetting);

            moveLeft.To = 455;
            moveTop.To = 253;

            story.Begin();

            /** Neklikat */
            Storyboard.SetTarget(moveLeft, btnNevim);
            Storyboard.SetTarget(moveTop, btnNevim);

            moveLeft.To = 509;
            moveTop.To = 246;

            story.Begin();
        }

        private void btnNevim_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Neumíte číst ? Neklikat !!!");
        }
    }
}
