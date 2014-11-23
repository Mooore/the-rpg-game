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
using System.IO;

namespace RPG_game_GUI.Menu
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : UserControl, ISwitchable
    {
        public Loading()
        {
            this.Height = App.Current.MainWindow.Height;
            this.Width = App.Current.MainWindow.Width;

            InitializeComponent();

            Wait(12);
        }

        /// <summary>
        /// Funkce která zajístí spoždění, než se zobrazí hra.
        /// </summary>
        /// <param name="seconds">Kolik sekund bude čekat</param>
        private void Wait(int seconds)
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(seconds) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                Switcher.Switch(new Gameplay.Gameplay());
            };
        }
        
        private void Card_Loaded(object sender, RoutedEventArgs e)
        {
            /*
             * Vygenerování náhodného obrázku
             */
            String img = "/RPG game GUI;component/Resources/Tarots/";
            Random random = new Random();

            img += random.Next(0, 77).ToString() + ".png";

            // Převod řetězce na ImageSource a přiřazení obrázku
            Uri source = new Uri(img, UriKind.Relative);
            BitmapImage image = new BitmapImage(source);
            Card.Source = image;
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void txtTooltip_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            // Načtení tipů do stringu
            string tips = Properties.Resources.tips;

            // Vygeneruje se náhodné číslo, které reprezentuje řádek s tipem (1 tip = 1 řádek)
            int tip = random.Next(0, 10); // Musí se zvýšit druhé číslo, pokud se dopíší tipy (počet řádků + 1)
            int counter = 0;

            // Vytvoření čtenáře pro řetězce
            StringReader reader = new StringReader(tips);
            string line;

            // Najde se příslušný tip
            do
            {
                line = reader.ReadLine();
                counter++;
            } while (counter < tip);


            // Načtení tipu do textboxu
            txtTooltip.Text = line;
        }
    }
}
