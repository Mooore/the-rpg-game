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

namespace RPG_game_GUI.Gameplay
{
    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : UserControl, ISwitchable
    {
        public Gameplay()
        {
            InitializeComponent();

            this.Height = App.Current.MainWindow.Height;
            this.Width = App.Current.MainWindow.Width;

            

            //double top = (GameCanvas.ActualHeight - element.ActualHeight) / 2;
            //Canvas.SetTop(element, top);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += UserControl_PreviewKeyDown;
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }


        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            /*
             * Zobrazení Triforce  
             */
            if (e.Key == Key.Tab || e.Key == Key.Escape)
            {
                if (vbTriforce.Visibility == Visibility.Visible)
                {
                    vbTriforce.Visibility = Visibility.Hidden;
                    vbBarBlur.Radius = 0;
                    vbCharBlur.Radius = 0;
                    vbMapBlur.Radius = 0;
                    vbBackground.Radius = 0;
                }
                else
                {
                    vbTriforce.Visibility = Visibility.Visible;
                    vbBarBlur.Radius = 10;
                    vbCharBlur.Radius = 10;
                    vbMapBlur.Radius = 10;
                    vbBackground.Radius = 10;
                    vbStatistics.Visibility = Visibility.Hidden;
                    vbAbilities.Visibility = Visibility.Hidden;
                    vbInventory.Visibility = Visibility.Hidden;
                    vbCharacter.Visibility = Visibility.Hidden;
                    vbTalents.Visibility = Visibility.Hidden;
                    vbworld_map.Visibility = Visibility.Hidden;
                }
            }

            /*
             * Zobrazení statistik
             */
            if (e.Key == Key.C && vbTriforce.Visibility == Visibility.Hidden)
            {
                if (vbStatistics.Visibility == Visibility.Visible)
                {
                    vbStatistics.Visibility = Visibility.Hidden;
                }
                else
                {
                    vbStatistics.Visibility = Visibility.Visible;
                }
            }

            /*
             * Zobrazení Dovedností
             */
            if (e.Key == Key.V && vbTriforce.Visibility == Visibility.Hidden)
            {
                if (vbAbilities.Visibility == Visibility.Visible)
                {
                    vbAbilities.Visibility = Visibility.Hidden;
                }
                else
                {
                    vbAbilities.Visibility = Visibility.Visible;
                }
            }

            /*
             * Zobrazení Inventáře
             */
            if (e.Key == Key.B && vbTriforce.Visibility == Visibility.Hidden)
            {
                if (vbInventory.Visibility == Visibility.Visible)
                {
                    vbInventory.Visibility = Visibility.Hidden;
                }
                else
                {
                    vbInventory.Visibility = Visibility.Visible;
                }
            }

            /*
             * Zobrazení Charakteru
             */
            if (e.Key == Key.X && vbTriforce.Visibility == Visibility.Hidden)
            {
                if (vbCharacter.Visibility == Visibility.Visible)
                {
                    vbCharacter.Visibility = Visibility.Hidden;
                }
                else
                {
                    vbCharacter.Visibility = Visibility.Visible;
                }
            }

            /*
             * Zobrazení Talentů
             */
            if (e.Key == Key.T && vbTriforce.Visibility == Visibility.Hidden)
            {
                if (vbTalents.Visibility == Visibility.Visible)
                {
                    vbTalents.Visibility = Visibility.Hidden;
                }
                else
                {
                    vbTalents.Visibility = Visibility.Visible;
                }
            }
            
            /*
             * Zobrazení Mapy
             */
            if (e.Key == Key.M && vbTriforce.Visibility == Visibility.Hidden)
            {
                if (vbworld_map.Visibility == Visibility.Visible)
                {
                    vbworld_map.Visibility = Visibility.Hidden;
                }
                else
                {
                    vbworld_map.Visibility = Visibility.Visible;
                }
            }
        }

        private void QuickBar_Loaded(object sender, RoutedEventArgs e)
        {
            double left = (GameCanvas.ActualWidth - QuickBar.ActualWidth) / 2;
            Canvas.SetLeft(QuickBar, left);
        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            if (win.WindowState.ToString() == "Maximized")
            {
                GameCanvas.Height = this.Height;
                GameCanvas.Width = this.Width;
            }
            else
            {
                GameCanvas.Height = this.Height - 30;
                GameCanvas.Width = this.Width - 20;
            }
            
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                // 1
                if (btnOne.Content == FindResource("button1_icon1"))
                {
                    btnOne.Content = FindResource("button1_icon2");
                }
                else if (btnOne.Content == FindResource("button1_icon2"))
                {
                    btnOne.Content = FindResource("button1_icon3");
                }
                else if (btnOne.Content == FindResource("button1_icon3"))
                {
                    btnOne.Content = FindResource("button1_icon4");
                }
                else if (btnOne.Content == FindResource("button1_icon4"))
                {
                    btnOne.Content = FindResource("button1_icon5");
                }
                else if (btnOne.Content == FindResource("button1_icon5"))
                {
                    btnOne.Content = FindResource("button1_icon6");
                }
                else if (btnOne.Content == FindResource("button1_icon6"))
                {
                    btnOne.Content = FindResource("button1_icon7");
                }
                else if (btnOne.Content == FindResource("button1_icon7"))
                {
                    btnOne.Content = FindResource("button1_icon1");
                }               
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                // 2
                if (btnTwo.Content == FindResource("button2_icon1"))
                {
                    btnTwo.Content = FindResource("button2_icon2");
                }
                else if (btnTwo.Content == FindResource("button2_icon2"))
                {
                    btnTwo.Content = FindResource("button2_icon3");
                }
                else if (btnTwo.Content == FindResource("button2_icon3"))
                {
                    btnTwo.Content = FindResource("button2_icon4");
                }
                else if (btnTwo.Content == FindResource("button2_icon4"))
                {
                    btnTwo.Content = FindResource("button2_icon5");
                }
                else if (btnTwo.Content == FindResource("button2_icon5"))
                {
                    btnTwo.Content = FindResource("button2_icon6");
                }
                else if (btnTwo.Content == FindResource("button2_icon6"))
                {
                    btnTwo.Content = FindResource("button2_icon7");
                }
                else if (btnTwo.Content == FindResource("button2_icon7"))
                {
                    btnTwo.Content = FindResource("button2_icon1");
                }
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                // 3
                if (btnThree.Content == FindResource("button3_icon1"))
                {
                    btnThree.Content = FindResource("button3_icon2");
                }
                else if (btnThree.Content == FindResource("button3_icon2"))
                {
                    btnThree.Content = FindResource("button3_icon3");
                }
                else if (btnThree.Content == FindResource("button3_icon3"))
                {
                    btnThree.Content = FindResource("button3_icon4");
                }
                else if (btnThree.Content == FindResource("button3_icon4"))
                {
                    btnThree.Content = FindResource("button3_icon5");
                }
                else if (btnThree.Content == FindResource("button3_icon5"))
                {
                    btnThree.Content = FindResource("button3_icon6");
                }
                else if (btnThree.Content == FindResource("button3_icon6"))
                {
                    btnThree.Content = FindResource("button3_icon7");
                }
                else if (btnThree.Content == FindResource("button3_icon7"))
                {
                    btnThree.Content = FindResource("button3_icon1");
                }
            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                // 4
                if (btnFour.Content == FindResource("button4_icon1"))
                {
                    btnFour.Content = FindResource("button4_icon2");
                }
                else if (btnFour.Content == FindResource("button4_icon2"))
                {
                    btnFour.Content = FindResource("button4_icon3");
                }
                else if (btnFour.Content == FindResource("button4_icon3"))
                {
                    btnFour.Content = FindResource("button4_icon4");
                }
                else if (btnFour.Content == FindResource("button4_icon4"))
                {
                    btnFour.Content = FindResource("button4_icon5");
                }
                else if (btnFour.Content == FindResource("button4_icon5"))
                {
                    btnFour.Content = FindResource("button4_icon6");
                }
                else if (btnFour.Content == FindResource("button4_icon6"))
                {
                    btnFour.Content = FindResource("button4_icon7");
                }
                else if (btnFour.Content == FindResource("button4_icon7"))
                {
                    btnFour.Content = FindResource("button4_icon1");
                }
            }
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                // 5
                if (btnFive.Content == FindResource("button5_icon1"))
                {
                    btnFive.Content = FindResource("button5_icon2");
                }
                else if (btnFive.Content == FindResource("button5_icon2"))
                {
                    btnFive.Content = FindResource("button5_icon3");
                }
                else if (btnFive.Content == FindResource("button5_icon3"))
                {
                    btnFive.Content = FindResource("button5_icon4");
                }
                else if (btnFive.Content == FindResource("button5_icon4"))
                {
                    btnFive.Content = FindResource("button5_icon5");
                }
                else if (btnFive.Content == FindResource("button5_icon5"))
                {
                    btnFive.Content = FindResource("button5_icon6");
                }
                else if (btnFive.Content == FindResource("button5_icon6"))
                {
                    btnFive.Content = FindResource("button5_icon7");
                }
                else if (btnFive.Content == FindResource("button5_icon7"))
                {
                    btnFive.Content = FindResource("button5_icon1");
                }
            }
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                // 6
                if (btnSix.Content == FindResource("button6_icon1"))
                {
                    btnSix.Content = FindResource("button6_icon2");
                }
                else if (btnSix.Content == FindResource("button6_icon2"))
                {
                    btnSix.Content = FindResource("button6_icon3");
                }
                else if (btnSix.Content == FindResource("button6_icon3"))
                {
                    btnSix.Content = FindResource("button6_icon4");
                }
                else if (btnSix.Content == FindResource("button6_icon4"))
                {
                    btnSix.Content = FindResource("button6_icon5");
                }
                else if (btnSix.Content == FindResource("button6_icon5"))
                {
                    btnSix.Content = FindResource("button6_icon6");
                }
                else if (btnSix.Content == FindResource("button6_icon6"))
                {
                    btnSix.Content = FindResource("button6_icon7");
                }
                else if (btnSix.Content == FindResource("button6_icon7"))
                {
                    btnSix.Content = FindResource("button6_icon1");
                }
            }
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                // 7
                if (btnSeven.Content == FindResource("button7_icon1"))
                {
                    btnSeven.Content = FindResource("button7_icon2");
                }
                else if (btnSeven.Content == FindResource("button7_icon2"))
                {
                    btnSeven.Content = FindResource("button7_icon3");
                }
                else if (btnSeven.Content == FindResource("button7_icon3"))
                {
                    btnSeven.Content = FindResource("button7_icon4");
                }
                else if (btnSeven.Content == FindResource("button7_icon4"))
                {
                    btnSeven.Content = FindResource("button7_icon5");
                }
                else if (btnSeven.Content == FindResource("button7_icon5"))
                {
                    btnSeven.Content = FindResource("button7_icon6");
                }
                else if (btnSeven.Content == FindResource("button7_icon6"))
                {
                    btnSeven.Content = FindResource("button7_icon7");
                }
                else if (btnSeven.Content == FindResource("button7_icon7"))
                {
                    btnSeven.Content = FindResource("button7_icon1");
                }
            }
        }
    }
}
